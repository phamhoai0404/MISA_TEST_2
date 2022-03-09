<template>
<div class="m-grid" id="m-grid" :style="{ maxHeight: height}">
    <table border="1" class="m-table">
        <thead>
            <tr>
                <th class=" m-checkbox-table sticky-checkbox" >
                    <BaseCheckbox :id="nameTable" @clickCheckbox="btnAllCheckbox"/>
                </th>
                <th v-for="(field,index) in listFields" :key="index" 
                    :style="{ 
                        minWidth: field.width +'px', 
                        textAlign: field.type =='number'? 'right':''|| field.type =='date'? 'center':''
                     }" 
                    :class="[index== 0 ? 'remove-border-left' : '']"
                >{{field.text}}</th>

                <th class="sticky-function text-align-center">CHỨC NĂNG</th>

            </tr>
        </thead>

        <tbody>
            <tr v-for="(data,index) in listData" :key="index">
                <td class="m-checkbox-table sticky-checkbox">
                    <BaseCheckbox :id="data[nameTable+'Id']" @clickCheckbox="btnCheckbox"/>
                </td>
                <td v-for="(field,i) in listFields" :key="i" 
                    :class="[i == 0 ? 'remove-border-left' : '']" 
                    :style="field.type =='number'?'text-align:right' : '' || field.type =='date'?'text-align:center' : ''"
                >
                    <span v-if="field.type == 'date' " >{{data[field.name] | formatDate }}</span>
                    <span v-else >{{data[field.name]}}</span>
                    
                </td>

                <td class="m-funtionsss sticky-function">
                    <div class="m-function">
                        <div class="m-title" @click="btnView(data)">Xem</div>
                        <button class="m-button-function">
                            <div class="m-button-icon" @click="btnDropDown($event, data , index)" id="clickFunction">
                            </div>
                        </button>
                    </div>

                </td>
            </tr>
            <tr v-if="hasFooterTable" class="m-footer-table">

                <td class="m-footer-sticky-left"></td>

                <td v-for="(field,index) in listFields" :key="index" 
                    :style="{ 
                        minWidth: field.width +'px', 
                        textAlign: field.type =='number'? 'right':''|| field.type =='date'? 'center':''
                    }" 
                >
                    <span v-if="field.type=='number'" style="text-align:right !important;">{{sumFieldNumber(field.name)}}</span>
                    <span v-else-if="index==0" style="font-family:Notosans-Semi-bold;">Tổng</span>
                    <span v-else ></span>
                </td>

                <td class="m-footer-sticky-right"></td>
            </tr>

        </tbody>

    </table>
</div>
</template>

<script>
import BaseCheckbox from '@/components/base/BaseCheckbox.vue'
import MyFunction from '@/js/function.js'
export default {
    components:{
        BaseCheckbox,
    },
    props:{
        nameTable:String,//Tên bảng muốn hiển thị
        height: {
            default: "300px",//Nếu không truyền vào mặc định là vậy,
            type:String
        },
        listFields:{//Các thông tin tiêu đề của bảng
            default:null,
            type:Array
        },
        listData:{//Trường dữ liệu 
            default:null,
            type:Array
        },
        hasFooterTable:{//Mặc định là không có chân
            default:false,
            type:Boolean
        }


    },
    methods:{
        /**
         * Thực hiện click vào chữ Xem
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnView(data){
            var me = this;
            me.$emit('btnView', {object:data});
        },
         /**
         * Thực hiện click vào dropdown
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnDropDown(event, data, index){
            var me = this;
            me.$emit('btnDropDown', {eve: event, object:data, index: index});
        },
        btnAllCheckbox({id}){
            var me = this;
            me.$emit('btnAllCheckbox', {id: id});
        },
        btnCheckbox({id}){
            var me = this;
            me.$emit('btnCheckbox', {id: id});
        },
        /**
         * Tính tổng các trường
         * CreatedBy: HoaiPT(08/03/2022)
         */
        sumFieldNumber(filed){
            let sum = 0;
            for(let i = 0 ;i<this.listData.length; i++){
               sum += this.listData[i][filed];
            }
           return sum;
        }
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
@import url(../../style/base/table-list.css);
.m-grid .remove-border-left{
    border-left:none;
}

</style>
