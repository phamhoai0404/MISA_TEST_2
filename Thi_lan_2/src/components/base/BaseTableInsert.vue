<template>
<div style="background-color: #ffff;" v-click-outside="cancelRow" >
    <div class="m-table-insert-group">
        <div class="m-grid-table-insert" :style="styleTable">
            <table border="1" class="m-table-insert">
                <thead v-if="showField">
                    <tr>
                        <th  v-if="isColumNumber == true" style="text-align:center">#</th>
                        <th v-for="(field,index) in listFields" :key="index" 
                            :style="{ 
                                width: field.width,
                                textAlign: field.type =='number'? 'right':''|| field.type =='date'? 'center':'',
                            }"
                        >
                            {{field.text}}
                        </th>
                        <th style="border-right:none;"></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(data,index) in listData" :key="index" >
                        <td  v-if="isColumNumber == true"
                            :style="{
                                borderTop:index==0?'1px solid #bbb':'',
                            }"
                            style="text-align:center"
                        >
                            {{index + 1}}
                        </td>

                        <td v-for="(field,i) in listFields" :key="i" 
                            :style="{
                                width: field.width,
                                borderTop:index==0?'1px solid #bbb':'',
                                backgroundColor:selectRowNumber==index?'#f5fbf9':'',  
                            }"
                            @click="clickItemRow(index,field.name+index,field.typeInsert)"
                        >
                            <div v-if="selectRowNumber != index" 
                               :style="{
                                display:field.type=='number'?'flex':'',
                                justifyContent:field.type=='number'?'flex-end':'',
                               }"
                            >
                                <span v-if="field.type == 'date' ">{{data[field.name] | formatDate }}</span>
                                <span v-else>{{data[field.name]}}</span>
                            </div>
                            <div v-if="selectRowNumber==index">
                                <span  v-if="field.typeInsert=='combobox'">
                                    <BaseComboboxNormal
                                        v-model="data[field.name]"
                                        :isComboboxTable="true"
                                        :listFields="field.listField"
                                        :datas="field.listData"
                                        :styleDataCombobox="field.styleCombobox"
                                        :ref="field.name + index"

                                        :inputText="field.name"
                                        :propertyCompare="data[field.keySearch]"
                                        :keySearch="field.keySearch" 

                                        @onChangeValueKeySearch ="changeKeySearchCombobox($event,field.keySearch,index)"
                                        @input="changeInputCombobox(field.keySearch,index)"
                                    />
                                </span>
                                <span  v-else-if="field.typeInsert=='none'"> 
                                    <span v-if="field.type == 'date' ">{{data[field.name] | formatDate }}</span>
                                    <span v-else>{{data[field.name]}}</span>
                                </span>
                                <span v-else>
                                    <input class="m-input-insert-table" 
                                        v-model="data[field.name]" 
                                        :ref="field.name + index"
                                        :readOnly="readOnly"
                                        :type="field.type=='number'?'number':'input'"
                                        :style="{
                                            textAlign:field.type=='number'?'right':''
                                        }"
                                        @blur="handleBlur(field.type, field.name, data[field.name],index)"
                                    />
                                </span>
                               
                            </div>
                        </td>
                        <td class="m-table-insert-icon" 
                            :style="{ 
                                borderTop:index==0?'1px solid #bbb':'',
                                backgroundColor:selectRowNumber==index?'#f5fbf9':'',
                            }"
                        >
                            <BaseButtonIcon iconClass="btn-mi-delete" :isSize16="true" @btnClick="deleteItemRow(index)" />
                        </td>
                    </tr>
                    <tr v-if="hasFooterTable" class="m-footer-table-insert">
                        <td></td>
                        <td v-for="(field,index) in listFields" :key="index" 
                            :style="{ 
                                minWidth: field.width +'px', 
                                textAlign: field.type =='number'? 'right':''|| field.type =='date'? 'center':''
                            }" 
                        >
                            <span v-if="field.type=='number'" style="text-align:right !important;">{{sumFieldNumber(listData,field.name)}}</span>
                            <span v-else ></span>
                        </td>
                        <td></td>
                    </tr>

                </tbody>
            </table>
        </div>
        <div class="m-table-insert-function" :style="{ marginTop:styleTable ==''?'50px':'',}">
            <div class="m-button-one" @click="addItemRow">Thêm dòng</div>
            <div class="m-button-one" @click="btnRemoveAll">Xóa hết dòng</div>
        </div>
    </div>
<BaseMessage typeMessage="warningAndQuestion" 
    v-if="isShowWarningAndQuestion"
    :titleForm="titleWarningAndQuestion"
    @btnNo="isShowWarningAndQuestion = false"
    @btnYes="removeAllItem"
/>
</div>
</template>

<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseMessage from '@/components/base/BaseMessage.vue'
import MyFunction from '@/js/function.js'
import * as mylib  from '@/js/resourcs.js'
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'


export default {
    components: {
        BaseButtonIcon,
        BaseMessage,
        BaseComboboxNormal
    },
    props: {
        readOnly: {//Xem có chỉ đọc hay không
            default: false,
            type: Boolean
        },
        showField: { //Có hiện thị các trường hay không
            default: true, //Mặc định là có show ra các trường
            type: Boolean
        },
        listFields: Array, //Truyền vào các field
        styleTable: {//Nếu muốn truyền thêm từ bên ngoài css vào table
            default:"",
            type:String, 
        },
        value:Array,//Phải chú ý cái này chính là v-model bên cha
        isColumNumber:{//Có hiện cột đánh số thứ tự hay không, mặc định là không đánh số thứ tự
            default:false,
            type:Boolean
        },
        hasFooterTable:{//Mặc định là không có chân
            default:false,
            type:Boolean
        }
        
    },
    data() {
        return {
            listData:this.value,//lấy nó gán bằng thằng v-model bên cha
            selectRowNumber:-1,//Không lựa chọn dòng nào hết

            isShowWarningAndQuestion:false,
            titleWarningAndQuestion:mylib.resourcs["VI"].questionRemoveAll,
        }
    },
    created(){
        var me = this;
        if(me.readOnly == false){//Nếu mà chỉ đọc thì không lựa chọn dòng nào hết
            me.selectRowNumber = 0;//Còn nếu mà sửa hoặc .. hành động khác thì cho trỏ  vào dòng đầu tiên
        }
    },
    mounted(){
        var me = this;
        if(me.readOnly == false){
            let fieldNameFirst= me.listFields[0].name + 0;//Lấy ra tên đầu tiên của ô đầu tiên
            me.focus(fieldNameFirst);
        }
    },
    watch:{
        value(valueNew){
            this.listData = valueNew;
        },
    },
    methods: {
        handleBlur(fieldType,fieldName, value,index){
            if(fieldType =='number'){
                if(value==''){
                    this.listData[index][fieldName] = 0;
                }
            }
        },
        changeKeySearchCombobox(object, fieldName, index){
            // console.log(object);
            this.$emit('changeSelectItem',{object, fieldName:fieldName, index:index})
        },
        changeInputCombobox(fieldName, index){
           this.$emit('changeInput',{fieldName:fieldName, index:index})
        },
        /**
         * Thực hiện update bên cha mới nhận được 
         * CreatedBy: HoaiPT(05/03/2022)
         */
        updateValue(data){
            var me = this;
            me.$emit('input',data);
        },
        /**
         * Thực hiện xóa lựa chọn dòng không lựa chọn dòng nào hết
         * CÁI NÀY CẦN PHẢI XEM LẠI VÌ NÓ KHÔNG ĂN MẤY
         * CreatedBy: HoaiPT(05/03/2022)
         */
        cancelRow() {
            var me = this;
            if (me.readOnly == false) {
            //    me.selectRowNumber = 0;//Không chọn vào dòng nào hết 
            }
        },
        /**
         * Thực hiện focus vào ô đang chọn
         * CreatedBy: HoaiPT(05/03/2022)
         */
        clickItemRow(index, fieldNameSelect,fieldTypeInsert) {
            var me = this;
            if (me.readOnly == false) {
                me.selectRowNumber = index;//Lực chọn dòng vừa chọn
                if(fieldTypeInsert !='none'){
                    me.focus(fieldNameSelect);// với focus ở ô đang chọn
                }
              
            }
        },
        /**
         * Thực hiện xóa một dòng đang chọn
         * CreatedBy: HoaiPT(05/03/2022)
         */
        deleteItemRow(index) {
            var me = this;
            if (me.readOnly == false) {
               me.listData.splice(index,1);//Xóa item đang chọn với vị trí index
               if(me.listData.length == 0){
                    me.listData.push({});//Thêm đối tượng rỗng vào cuối
               }

               me.updateValue(me.listData);//Thực hiện update bên cha
            }
        },
        /**
         * Thực hiện add thêm một dòng cuối cùng và đồng thời focus vào ô
         * CreatedBy: HoaiPT(05/03/2022)
         */
        addItemRow() {
            var me = this;
            if (me.readOnly == false) {//Nếu không phải là chỉ đọc

                me.listData.push({});//Thêm đối tượng rỗng vào cuối
                me.selectRowNumber = me.listData.length-1;//Lựa chọn focus dòng vừa mới tạo

                let fieldNameFocusLast = me.listFields[0].name+me.selectRowNumber;//Lấy ra tên đầu tiên ở dòng cuối cùng để focus
                me.focus(fieldNameFocusLast);
                
                me.updateValue(me.listData);//Thực hiện update bên cha thì mới hiểu được
            }
        },
        /**
         * Thực hiện khi click nút xóa tất cả
         * CreatedBy: HoaiPT(05/03/2022)
         */
        btnRemoveAll(){
            var me = this;
            if (me.readOnly == false) {
                me.selectRowNumber = -1;//Không chọn dòng nào hết
                me.isShowWarningAndQuestion = true;
            }
        },
        /**
         * Thực hiện khi xóa tất cả các item đồng thời để lại một dòng đầu tiên và focus vào dòng đấy với ô đầ tiên
         * CreatedBy: HoaiPT(05/03/2022)
         */
        removeAllItem() {
            var me = this;
            if (me.readOnly == false) {
                me.listData=[];//Làm rỗng đối tượng
                me.isShowWarningAndQuestion = false;//Đóng form cảnh báo

                me.listData.push({});//push đối tượng rỗng vào
                me.selectRowNumber = 0;//Lựa chọn select vào dòng đầu tiên trong bảng

                let fieldNameFocusLast = me.listFields[0].name+me.selectRowNumber;//Focus vào cái ô đầu tiên của dòng dầu tiên với selectRowNumber = 0;
                me.focus(fieldNameFocusLast);

                me.updateValue(me.listData);//Thực hiện update thì cha mới hiểu được
                
                
            }
        },

        /**
         * Thực hiện focus vào ô đang chọn vì :refs
         * CreatedBy: HoaiPT(05/03/2022)
         */
        focus(fieldName) {
            var me = this;
            me.$nextTick(() => {
                me.$refs[fieldName][0].focus();
            })
        },
        sumFieldNumber:MyFunction.sumFieldNumber,
        
    }
}
</script>

<style scoped>
@import url(../../style/base/table-insert.css);
</style>
