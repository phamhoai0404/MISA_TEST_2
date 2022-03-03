<template>
    <div>
        <BaseComboboxGroup 
            v-model="textSearchAccountObjectGroup" :isButtonAdd="true"
            :isShowDataDropdown="isShowDropDownAccountObjectGroup"
            :listData="listAccountObjectGroupTemp"
            :listFields="listFieldAccountObjectGroup"
            :listDataSelected="listAccountGroupSelected"
            @btnClickDropdown="btnClickDropdownAccountObjectGroup"
            @btnClickItemTable="btnSelectItemAccountObjectGroup"
            @hideDataDropDown="isShowDropDownAccountObjectGroup = false"
            @removeOneItem="removeOneAccountObjectGroup"
            keySearch="AccountObjectGroupCode"
        />
        
    </div>
</template>
<script>

import BaseComboboxGroup from '@/components/base/BaseComboboxGroup.vue'
import * as mylib from '@/js/resourcs.js'
import MyFunction from '@/js/function.js'
export default {
    components:{
        BaseComboboxGroup,
    },
    watch:{
        'textSearchAccountObjectGroup'( valueNew){
            var me = this;
            me.isShowDropDownAccountObjectGroup = true;
            me.listAccountObjectGroupTemp = me.selectFilterObject(me.listAccountObjectGroup,'AccountObjectGroupName', valueNew);
          
        },
        
    },
    created(){
        var me = this;
        this.listAccountGroupSelected = me.cutStrings(me.account.AccountObjectGroupListId);
        console.log(this.listAccountGroupSelected);
    },
    data() {
        return {
            isShowDropDownAccountObjectGroup:false,
            listAccountObjectGroup:mylib.dataTest.listAccountObjectGroup,
            listAccountObjectGroupTemp:[],
            listFieldAccountObjectGroup:mylib.data.listFieldAccountObjectGroupCombobox,

            account:mylib.dataTest.accountTest,
            listAccountGroupSelected:new Array(),//Đầu tiên là mảng rỗng
            textSearchAccountObjectGroup:""
        }
    },
    methods:{
        removeOneAccountObjectGroup({object,index}){
            console.log('đối tượng:', object, '-chỉ số:', index);
            this.listAccountGroupSelected.splice(index, 1);
        },
        changeInputCombobox(){

        },
        btnClickDropdownAccountObjectGroup(){
            this.listAccountObjectGroupTemp = this.listAccountObjectGroup;
            this.isShowDropDownAccountObjectGroup = !this.isShowDropDownAccountObjectGroup;
        },
        btnSelectItemAccountObjectGroup({object}){
            console.log('object:', object);
            var me = this;
            // this.isShowDropDownAccountObjectGroup = false;  
            if(me.existValueInArray2(me.listAccountGroupSelected,object.AccountObjectGroupCode)){
                me.listAccountGroupSelected = me.removeValueInArray(me.listAccountGroupSelected,object.AccountObjectGroupCode);
            }else{
                me.listAccountGroupSelected.push(object.AccountObjectGroupCode);
            }
        },
        selectFilter:MyFunction.selectFilter,
        existValueInArray:MyFunction.existValueInArray,
        existValueInArray2:MyFunction.existValueInArray2,
        existValueInArrayObject:MyFunction.existValueInArrayObject,
        selectFilterObject:MyFunction.selectFilterObject,
        sameObject:MyFunction.sameObject,
        cutStrings:MyFunction.cutStrings,
        removeValueInArray:MyFunction.removeValueInArray,
        
    }
}
</script>


<style scoped>
</style>