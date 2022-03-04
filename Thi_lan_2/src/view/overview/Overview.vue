<template>
    <div>
        <BaseTableInsert
            :listFields="listFieldBank"
            :listData="listAccountObjectBankAccount"
            :selectRowNumber="selectRowBank"
            @clickItemRow="selectRowBankAction"
            @cancelSelectRow="selectRowBank = -1"
            @deleteItemRow="deleteItemBank"
            @addItemRow="addItemBank"
            @removeAllItem="removeAllBank"
            ref="listBank"
        />
        <div @click="hien">sfs</div>
    </div>
    
</template>
<script>
import BaseTableInsert from '@/components/base/BaseTableInsert.vue'

import * as mylib from '@/js/resourcs.js'
import MyFunction from '@/js/function.js'
export default {
    components:{
       BaseTableInsert
    },
    watch:{
        
        
    },
    mounted(){
         this.$refs.listBank.focus("BankAccountNumber0");
    },
    data() {
        return {
            listFieldBank:mylib.data.listFieldBank,
            listAccountObjectBankAccount: mylib.dataTest.listBank,
            selectRowBank:0,
        }
    },
    methods:{
        selectRowBankAction({index,fieldName}){
            var me = this;
            me.selectRowBank = index;
            let refIndex = fieldName+index;
            this.$refs.listBank.focus(refIndex);
           
        },
        deleteItemBank({object,index}){
            console.log(object,index);
            var me= this;
            me.listAccountObjectBankAccount.splice(index,1);
        },
        addItemBank(){
            var me = this;
            me.listAccountObjectBankAccount.push({});

        },
        removeAllBank(){
            var me = this;
            me.listAccountObjectBankAccount=[];
            //CHÚ Ý CÁI NÀY NÓ KHÔNG ĂN 
            // me.selectRowBank = 0;
            // me.$refs.listBank.focus("BankAccountNumber0");
        },
        hien(){
            var me = this;
            me.listAccountObjectBankAccount = me.listAccountObjectBankAccount.filter(item=> me.existObject(item) );
            console.log(me.listAccountObjectBankAccount);
        },
        existObject:MyFunction.existObject,
    }
}
</script>


<style scoped>
</style>