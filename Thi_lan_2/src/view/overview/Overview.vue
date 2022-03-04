<template>
    <div>
        <BaseTableInsert
            :listFields="listFieldBank"
            :datas="listAccountObjectBankAccount"
            @btnRemoveAll="btnRemoveAll"
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
        //  this.$refs.listBank.focus("BankAccountNumber0");
    },
    data() {
        return {
            listFieldBank:mylib.data.listFieldBank,
            listAccountObjectBankAccount: mylib.dataTest.listBank,
            
        }
    },
    methods:{
        //Đây là con bắn về 
        btnRemoveAll(){
           var me = this;
           console.log("đó nha");
           me.$children.removeAllItem();//Cái này con có ở trong cái function thì cha mới nhận được
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