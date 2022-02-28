<template>
    <div>
        <BaseComboboxNormal 
            v-model="xinhgai"
            :isRequire = "true"
            :errorCombobox="checkCombobox"
            @btnClickDropdown="btnClickDropdownDemo"
            @btnClickItem="btnSelectItem"
            :isShowDataDropdown="isShowDropDown"
            :listData="listDataVocativeTemp"
            @hideDataDropDown="isShowDropDown = false"
        />
        sfsfsf
    </div>
</template>
<script>
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import * as mylib from '@/js/resourcs.js'

export default {
    components:{
        BaseComboboxNormal
    },
    watch:{
        xinhgai:function(valueNew ){
            var me = this;
            if(!me.existValueInArray(me.listDataVocative, valueNew)){
                me.isShowDropDown = true;
                me.listDataVocativeTemp = me.selectFilter(me.listDataVocative,valueNew);
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
            xinhgai:null,
            checkCombobox:false,
            listDataVocative:mylib.data.listVocative,
            listDataVocativeTemp:[],
        }
    },
    methods:{
        btnClickDropdownDemo(){
            this.listDataVocativeTemp = this.listDataVocative;
            this.isShowDropDown = !this.isShowDropDown;
        },
        btnSelectItem({object}){
            console.log('object:', object);
            this.xinhgai = object;
            this.isShowDropDown = false;  
        },
        /**
         * Thực hiện tìm kiếm những giá trị trong dãy thỏa mãn dữ kiện đầu vào là và dãy ban đầu là arrayList value
         * .toLowerCase(): Thực hiện chuyển về chữ thường để so sánh cho được nhiều nhất
         * CreatedBy: HoaiPT(28/02/2022)
         */
        selectFilter(arrayList, value){
            return arrayList.filter(itemValue => itemValue.toLowerCase().includes(value.toLowerCase()));
        },
        /**
         * Thực hiện kiểm tra xem giá trị có tồn tại trong dãy
         * CreatedBy: HoaiPT(28/02/2022)
         */
        existValueInArray(arrayList, value){
            let arrayListTemp = arrayList.filter(itemValue => itemValue == value);
            if(arrayListTemp.length > 0)
                return true;
            return false;
        }
    }
}
</script>


<style scoped>

</style>