<template>
<div style="background-color: #ffff;" v-click-outside="cancelRow" >
    <div class="m-table-insert-group">
        <div class="m-grid-table-insert" :style="styleTable">
            <table border="1" class="m-table-insert">
                <thead v-if="showField">
                    <tr>
                        <th v-for="(field,index) in listFields" :key="index" :style="{ 
                                width: field.width,
                                textAlign: field.type =='number'? 'right':''|| field.type =='date'? 'center':'',
                            }">{{field.text}}</th>
                        <th style="border-right:none;"></th>

                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(data,index) in listData" :key="index" class="" :class="[     
                        ]">
                        <td v-for="(field,i) in listFields" :key="i" :style="{
                                textAlign:field.type =='number'?'right' : '' ,
                                textAlign:field.type =='date'?'center' : '',
                            }" @click="clickItemRow(index,field.name+index)">
                            <div v-if="selectRowNumber != index">
                                <span v-if="field.type == 'date' ">{{data[field.name] | formatDate }}</span>
                                <span v-else>{{data[field.name]}}</span>
                            </div>
                            <div v-if="selectRowNumber==index">
                                <input class="m-input-insert-table" 
                                    v-model="data[field.name]" 
                                    :ref="field.name + index" 
                                />
                            </div>
                        </td>
                        <td class="m-table-insert-icon">
                            <BaseButtonIcon iconClass="btn-mi-delete" :isSize16="true" @btnClick="deleteItemRow(data,index)" />
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
        <div class="m-table-insert-function">
            <div class="m-button-one" @click="addItemRow">Thêm dòng</div>
            <div class="m-button-one" @click="removeAllItem">Xóa hết dòng</div>
        </div>
    </div>
</div>
</template>

<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
// import { set } from 'vue/types/umd';
// import MyFunction from '@/js/function.js'

export default {
    components: {
        BaseButtonIcon
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
        datas: Array, //Dữ liệu truyền vào,
        listFields: Array, //Truyền vào các field
        styleTable: String //Nếu muốn truyền thêm từ bên ngoài css vào table
    },
    data() {
        return {
            listData:this.datas,//Cần phải viết lại như này thì mới không có lỗi là Avoid mutating a prop directly ....
            selectRowNumber:0,
        }
    },
    methods: {
        /**
         * Thực hiện xóa lựa chọn dòng không lựa chọn dòng nào hết
         * CreatedBy: HoaiPT(05/03/2022)
         */
        cancelRow() {
            var me = this;
            if (me.readOnly == false) {
               me.selectRowNumber = -1;//Không chọn vào dòng nào hết 
            }
        },
        /**
         * Thực hiện xóa lựa chọn dòng không lựa chọn dòng nào hết
         * CreatedBy: HoaiPT(05/03/2022)
         */
        clickItemRow(index, fieldNameSelect) {
            var me = this;
            if (me.readOnly == false) {
                me.selectRowNumber = index;//Lực chọn dòng vừa chọn 
                me.focus(fieldNameSelect);//Cùng với focus ở ô đang chọn
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
            }
        },
        /**
         * Thực hiện khi click nút xóa tất cả
         * CreatedBy: HoaiPT(05/03/2022)
         */
        btnRemoveAll(){
            var me = this;
            if (me.readOnly == false) {
                me.$emit('btnRemoveAll');
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
                me.listData.push({});//push đối tượng rỗng vào
                me.selectRowNumber = 0;//Lựa chọn select vào dòng đầu tiên trong bảng

                let fieldNameFocusLast = me.listFields[0].name+me.selectRowNumber;//Focus vào cái ô đầu tiên của dòng dầu tiên với selectRowNumber = 0;
                me.focus(fieldNameFocusLast);
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
        }
    }
}
</script>

<style scoped>
@import url(../../style/base/table-insert.css);
</style>
