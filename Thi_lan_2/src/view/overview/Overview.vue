<template>
    <div>
        <BaseComboboxNormal 
            v-model="xinhgai.FullName"
            :isComboboxTable="true"
            :errorCombobox="checkCombobox"
            @btnClickDropdown="btnClickDropdownDemo"
            @btnClickItemTable="btnSelectItem"
            :isShowDataDropdown="isShowDropDown"
            :listData="listDataVocativeTemp"
            :listFields="listFieldsTest"
            @hideDataDropDown="isShowDropDown = false"
            keySearch="EmployeeId"
            :object="xinhgai"
            @input="changeInputCombobox"
        />
        sfsfsf
    </div>
</template>
<script>
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import * as mylib from '@/js/resourcs.js'
import MyFunction from '@/js/function.js'
export default {
    components:{
        BaseComboboxNormal
    },
    watch:{
        'xinhgai.FullName'( valueNew,valueOld){
            var me = this;
            // me.xinhgai.EmployeeId = null;//Thiết lập về trạng thái rỗng để không ăn với css
            console.log(valueNew, valueOld);
            if(!me.existValueInArrayObject(me.listDataVocative,'FullName', valueNew)){
                me.isShowDropDown = true;
                me.listDataVocativeTemp = me.selectFilterObject(me.listDataVocative,'FullName', valueNew);
            } 
        },
        
    },
    created(){
        var me = this;
        console.log(me.listDataVocative);
    },
    data() {
        return {
            isShowDropDown:false,
            xinhgai:{
                EmployeeCode:null,
                FullName:null,
            },
            checkCombobox:false,
            listDataVocative:mylib.dataTest.listEmployee,
            listDataVocativeTemp:[],
            listFieldsTest:mylib.data.listFieldEmployeeCombobox,
        }
    },
    methods:{
        changeInputCombobox(){
            this.xinhgai.EmployeeId = null;
        },
        btnClickDropdownDemo(){
            this.listDataVocativeTemp = this.listDataVocative;
            this.isShowDropDown = !this.isShowDropDown;
        },
        btnSelectItem({object}){
            console.log('object:', object);
            this.xinhgai = this.sameObject(object);
            this.isShowDropDown = false;  
        },
        selectFilter:MyFunction.selectFilter,
        existValueInArray:MyFunction.existValueInArray,
        existValueInArrayObject:MyFunction.existValueInArrayObject,
        selectFilterObject:MyFunction.selectFilterObject,
        sameObject:MyFunction.sameObject,
    }
}
</script>


<style scoped>
</style>