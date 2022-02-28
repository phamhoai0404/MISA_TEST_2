<template>
    <div>
        <BaseComboboxNormal 
            v-model="xinhgai"
            :isRequire = "true"
            :errorCombobox="checkCombobox"
            @btnClickDropdown="btnClickDropdownDemo" 
            :isShowDataDropdown="isShowDropDown"
            :listData="listDataVocative"

        />
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
            if(valueNew==""){
                this.checkCombobox = true;
            }else{
                this.checkCombobox = false;
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
        }
    },
    methods:{
        btnClickDropdownDemo(){
            this.isShowDropDown = !this.isShowDropDown;
        }
    }
}
</script>


<style scoped>

</style>