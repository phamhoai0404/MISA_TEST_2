<template>
<div style="background-color: #ffff;">
    <div class="m-table-insert-group" >
        <div class="m-grid-table-insert" :style="styleTable">
            <table border="1" class="m-table-insert" v-click-outside="cancelRow">
                <thead v-if="showField">
                    <tr>
                        <th v-for="(field,index) in listFields" :key="index"
                            :style="{ 
                                width: field.width,
                                textAlign: field.type =='number'? 'right':''|| field.type =='date'? 'center':'',
                            }"
                        
                        >{{field.text}}</th >
                        <th style="border-right:none;"></th>
                        
                    </tr>
                </thead>
                <tbody>
                    <tr  v-for="(data,index) in listData" :key="index"  class="" 
                        :class="[     
                        ]" 
                    >
                        <td v-for="(field,i) in listFields" :key="i"
                            :style="{
                                textAlign:field.type =='number'?'right' : '' ,
                                textAlign:field.type =='date'?'center' : '',
                            }"
                            @click="clickItemRow(index,field.name)"
                        >
                            <div v-if="selectRowNumber != index">
                                <span v-if="field.type == 'date' " >{{data[field.name] | formatDate }}</span>
                                <span v-else >{{data[field.name]}}</span>
                            </div>
                            <div v-if="selectRowNumber==index">
                                <input class="m-input-insert-table"
                                    v-model="data[field.name]"
                                    :ref="field.name + index"
                                />
                            </div>   
                        </td>
                        <td class="m-table-insert-icon">
                            <BaseButtonIcon iconClass="btn-mi-delete" :isSize16="true" @btnClick="deleteItemRow(data,index)"/>
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
// import MyFunction from '@/js/function.js'

export default {
    components:{
        BaseButtonIcon
    },
    props: {
        readOnly:{
            default:false,
            type:Boolean
        },
        listData:Array,//Dữ liệu truyền vào,
        listFields:Array, //Truyền vào các field
        showField:{//Có hiện thị các trường hay không
            default:true,//Mặc định là có show ra các trường
            type:Boolean
        },
        selectRowNumber:{
            default:2,
            type:Number
        },
        styleTable:String//Nếu muốn truyền thêm từ bên ngoài css vào table
    },
    



    methods: {
        cancelRow(){
            var me = this;
            if(me.readOnly==false){
                me.$emit('cancelSelectRow');
            }
        },
        clickItemRow(index,fieldName){
            var me = this;
            if(me.readOnly==false){
                me.$emit('clickItemRow',{index:index,fieldName:fieldName});
            }
        },
        deleteItemRow(data,index){
            var me = this;
            if(me.readOnly==false){
                me.$emit('deleteItemRow',{object:data,index:index});
            }
        },
        addItemRow(){
            var me =this;
            if(me.readOnly == false){
                me.$emit('addItemRow');
            }
        },
        removeAllItem(){
            var me = this;
            if(me.readOnly == false){
                me.$emit('removeAllItem');
            }
        },

        focus(fieldName){
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
