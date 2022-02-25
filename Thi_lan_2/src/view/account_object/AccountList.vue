<template>
    <div>Nhà cung cấp table
         <BaseInputIcon :placeholder="'Tìm kiếm theo tên'" v-model="xinhgai"/>
         <BaseButtonIcon :iconClass="'btn-refresh'" @btnClick="action()" :title="'Load lại dữ liệu'"/>
         <BaseButtonIcon :iconClass="'btn-excel'" @btnClick="actionExcel()"  :title="'Xuất ra excel'" />
         <BaseButtonIcon :iconClass="'btn-arrow-check-all'" @btnClick="actionExcel()"  :title="'Xuất ra excel'" />
         <BaseButtonFunction @btnClick="actionFunction()" :width="'150px'" :label="'Tìm kiếm'"/>
         <BaseButtonFunction @btnClick="actionFunction()" :width="'200px'" :label="'Cứ thế thôi'" :hasBackground="true"/>
         <BaseTablePaging @btnClick="actionFunction()" :width="'200px'" :label="'Cứ thế thôi'" :hasBackground="true"/>
    </div>
   
</template>
<script>
import BaseInputIcon from '@/components/base/BaseInputIcon.vue'
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseButtonFunction from '@/components/base/BaseButtonFunction.vue'
import BaseTablePaging from '@/components/base/BaseTablePaging.vue'

export default {
    components: {
        BaseInputIcon,
        BaseButtonIcon,
        BaseButtonFunction,
        BaseTablePaging
    },
    data() {
        return {
            xinhgai:"đó nha"
        }
    },
    watch:{
        // xinhgai:function(valueNew, valueOld ){
        //     console.log(valueNew, valueOld);
        // }
    },
    methods: {
        action(){
            alert("xinh gái");
        },
         actionFunction(){
            alert("xinh gái excel");
        }
    },
}
</script>

<style scoped>

</style>