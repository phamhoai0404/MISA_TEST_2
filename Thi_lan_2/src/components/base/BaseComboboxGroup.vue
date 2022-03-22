<template>
<div :style="styleComboboxGroup" v-click-outside="hideDataDropDown" :title="title">
    <div v-if="label" class="m-label">
        <div>{{label}}</div>&nbsp;
        <div v-if="isRequire" style="color:red;">*</div>
    </div>
    <div class="m-combobox-group" >
        <div class="m-combobox-top m-over-size-combobox" :class=" [ isShowDataDropdown?'m-combobox-border-green':'',errorCombobox? 'm-combobox-border-red':'', readOnly?'m-combobox-readOnly':'']">
            <div class="m-combobox-selected-group " >
                <div v-for="(itemSelect,index) in listDataSelected" :key="index" class="m-item-selected">
                    <div class="m-item-text">{{itemSelect}}</div>
                    <BaseButton iconClass="btn-close-small" :isSize16="true" styleButtonIcon="margin-left:4px;" @btnClick="removeItemSelected(itemSelect,index)"/>
                </div>
                <input class="m-input-combobox m-input-group"
                    :placeholder="[[placeholder]]"  
                    :value="value" @input="onInput($event.target.value)"
                    :ref="refText"
                    :readonly="readOnly"
                >
            </div>
            <div class="m-combobox-icon">
                <div  v-if="isButtonAdd" class="m-button-dropdown" style="border-right:1px solid #bbb;" >
                    <BaseButton iconClass="btn-plus-success" :isSize16="true"/>
                </div>
                <div class="m-button-dropdown m-button-final" @click="btnClickDropdown" :class="[isShowDataDropdown? 'm-icon-dropdown-rotation': '']">
                    <BaseButton iconClass="btn-icon-drown" :isSize16="true" />
                </div>
               
            </div>
        </div>
        <!-- Dùng cho combobox có dữ liệu là table -->
        <div class="m-combobox-data table-combo m-combobox-data-group" v-if="isShowDataDropdown" :style="styleDataCombobox">
            <table border="1" class="m-table-combobox">
                <thead>
                    <tr>
                        <th v-for="(field,index) in listFields" :key="index"
                            :style="{ 
                                width: field.width,
                                textAlign: field.type =='number'? 'right':''|| field.type =='date'? 'center':''
                            }"
                        
                        >{{field.text}}</th >
                        <th></th>
                    </tr>
                </thead>
                <tbody>  
                    <tr  v-for="(data,index) in listData" :key="index"  class="m-combobox-item-" 
                        
                    >
                        <td v-for="(field,i) in listFields" :key="i"
                            :style="field.type =='number'?'text-align:right' : '' || field.type =='date'?'text-align:center' : ''"
                            @click="btnClickItemTable(data)"
                        >
                            <span v-if="field.type == 'date' " >{{data[field.name] | formatDate }}</span>
                            <span v-else >{{data[field.name]}}</span>
                        </td>
                        <td class="m-combobox-sign">
                            <span v-if="existValueInArray(listDataSelected,data[keySearch])">
                                <BaseButton iconClass="btn-item-selected" :isSize16="true"/>
                            </span>
                        </td>
                    </tr>
                    <tr v-if="listData.length == 0" class="m-combobox-item- m-combobox-no-item">
                        <td :colspan="listFields.length+1" >Không có dữ liệu hiển thị</td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>
</div>
</template>

<script>
import BaseButton from '@/components/base/BaseButtonIcon.vue'
import MyFunction from '@/js/function.js'

export default {
    components:{
        BaseButton
    },
    props: {
        label: {
            default: "",
            type: String
        },
        title:{
            default:"",
            type:String
        },
        isRequire: { //Xem trường có bắt buộc có hay không
            default: false,
            type: Boolean
        },
        value: [String,Number,Object],
        refText:String,
        placeholder:String,
        readOnly:{
            default:false,
            type:Boolean
        },
        isButtonAdd:{
            default:false,
            type:Boolean,
        },
        styleComboboxGroup:String,//Trường hợp muốn thêm css gì đó từ cha vào
        styleDataCombobox:String,
        styleBorder:{//Mặc định là không border
            default:'',
            type:String
        },
        errorCombobox:{
            default:false,//Mặc định là không có lỗi,
            type:Boolean
        },
        datas:Array,//Dữ liệu truyền vào,
        listFields:Array, //Truyền fields nếu là là isComboboxTable

        keySearch:String,//Để mục đích css,

        listDataSelectedSource:Array(),

        searchAllField:{//Có tìm kiếm theo tất cả các trường có trong fied không
            default:true,// có tìm kiếm tất cả nếu là false thì chỉ tìm kiếm theo giá trị inputText
            type:Boolean
        },
        inputText:{//Trường dữ liệu để tìm kiếm nếu searchAllField == false
            type:String
        },
    },

    data() {
        return {
            listDataSource: this.datas,
            listDataSelected :this.listDataSelectedSource,
            listData:[],//Dữ liệu temp để tìm kiếm ở combobox ấy,
            isShowDataDropdown: false,//Mặc định là đóng dropdown data
        }
    },
    watch:{
         /**
         * Thực hiện theo dõi những chữ trong ô input của combobox của 
         * CreatedBy: HoaiPT(02/03/2021)
         */
        value(valueNew){
            var me = this;
            me.isShowDataDropdown = true;

            if(me.searchAllField == false){//Nghĩa là không tìm tất cả
                me.listData = me.selectFilterObject(me.listDataSource,me.inputText, valueNew);
            }else{//Tìm tất cả các field
               me.listData = me.selectFilterObjectInAllField(me.listDataSource, me.listFields, valueNew);
            }
            
        },
        listDataSelectedSource(){//Thực hiện cập nhật dữ liệu mới
            this.listDataSelected = this.listDataSelectedSource;
        }
    },
    methods: {
        /**
         * Thực hiện khi thay đổi giá trị trong ô Input
         * CreatedBy: HoaiPT(28/02/2022)
         */
        onInput(value) {
            this.$emit('input', value) //Mặc định phải tên là 'input' thì nó mới map được với model ở bên ngoài không là nó không map được đâu
        },
        /**
         * Thực hiện thay đổi giá trị của listDataSelectedSource
         * CreatedBy: HoaiPT(02/03/2022)
         */
        onChangeListSelected(value){
            this.$emit('onChangeListSelected', value)
        },
        /**
         * Thực hiện khi click vào nút bỏ 1 item
         * CreatedBy: HoaiPT(02/03/2022)
         */
        removeItemSelected(object,index){
            var me = this;
            if(!this.readOnly){//Nếu mà không có lệnh chỉ đọc thì mới được thực hiện ở bên trong
                this.listDataSelected.splice(index, 1);
                me.$emit('updateListDataSelected',this.listDataSelected);
            }
        },
        /**
         * Thực hiện click nút dropdown
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnClickDropdown(){
            if(!this.readOnly){//Nếu mà không có lệnh chỉ đọc thì mới được thực hiện ở bên trong
                this.listData = this.datas;
                this.isShowDataDropdown = !this.isShowDataDropdown;
            }
        },
        /**
         * Thực hiện click vào một Item bất kỳ
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnClickItemTable(object){
            var me = this;
            if(me.existValueInArray(me.listDataSelected, object[this.keySearch])){
                me.listDataSelected = me.removeValueInArray(me.listDataSelected, object[this.keySearch]);
            }else{
                me.listDataSelected.push(object[this.keySearch]);
                
            }
            me.$emit('updateListDataSelected',this.listDataSelected);
        },

        /**
         * Thực hiện khi click bất kì ngoài ô đấy thì nó sẽ đóng lại
         * CreatedBy: HoaiPT(02/03/2022)
         */
        hideDataDropDown(){
           this.isShowDataDropdown = false;
        },
        existValueInArray:MyFunction.existValueInArray2,
        selectFilterObject:MyFunction.selectFilterObject,
        removeValueInArray:MyFunction.removeValueInArray,
        selectFilterObjectInAllField:MyFunction.selectFilterObjectInAllField,
    },
     filters: {
        /**
         * Thực hiện định dạng lại ngày
         * CreatedBy: HoaiPT(01/03/2022)
         */
        formatDate:MyFunction.formatDate,
    }
}
</script>

<style scoped>
@import url(../../style/base/combobox-group.css);
</style>
