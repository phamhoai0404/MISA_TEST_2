<template>
    <div>Nhà cung cấp table
         <BaseInputIcon :placeholder="'Tìm kiếm theo tên'" v-model="xinhgai"/>
         <BaseButtonIcon :iconClass="'btn-refresh'" @btnClick="action()" :title="'Load lại dữ liệu'"/>
         <BaseButtonIcon :iconClass="'btn-excel'" @btnClick="actionExcel()"  :title="'Xuất ra excel'" />
         <BaseButtonIcon :iconClass="'btn-arrow-check-all'" @btnClick="actionExcel()"  :title="'Xuất ra excel'" />
         <BaseButtonFunction @btnClick="actionFunction()" :width="'150px'" :label="'Tìm kiếm'"/>
         <BaseButtonFunction @btnClick="actionFunction()" :width="'200px'" :label="'Cứ thế thôi'" :hasBackground="true"/>
         <BaseTablePaging 
            @btnClick="actionFunction()" 
            :isShowPage="isShowPage"
            @btnSelectPage="btnSelectPage()" 
            @selectedPageText="selectedPageText"
            @clickCallback="clickCallback"
            :listPageText="listPageText"
            :totalRecord="totalRecord"
            :pageAction="pageAction"
            :totalPage="totalPage"
            :selectTextPage="selectTextPage"
        />
        <BaseTableList/>
    </div>
   
</template>
<script>
import BaseInputIcon from '@/components/base/BaseInputIcon.vue'
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseButtonFunction from '@/components/base/BaseButtonFunction.vue'
import BaseTablePaging from '@/components/base/BaseTablePaging.vue'
import BaseTableList from '@/components/base/BaseTableList.vue'

import * as mylib from '../../js/resourcs.js'
export default {
    components: {
        BaseInputIcon,
        BaseButtonIcon,
        BaseButtonFunction,
        BaseTablePaging,
        BaseTableList
    },
    data() {
        return {
            xinhgai:"đó nha",


            isShowPage: false,
            listPageText:mylib.data.listPageSize,
            totalRecord:0,
            pageAction:1,
            totalPage:10,
            selectTextPage: 10
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
        },
        btnSelectPage(){
            var me =this;
            me.isShowPage = !me.isShowPage;
        },
        selectedPageText({index}){
            var me = this;
            me.selectTextPage = me.listPageText[index]; //Thực hiện gán số kích thước trang đã lựa chọn 
            me.isShowPage = false; //Đóng form page
            me.totalPage = 4;
            me.totalRecord = 100;
            console.log("chỉ số: " + index +", kích thước trang: " + me.selectTextPage);
        },
        clickCallback({number}){
            var me = this;
            console.log("number: " + number);
            me.pageAction = number;
        }
    },
}
</script>

<style scoped>

</style>