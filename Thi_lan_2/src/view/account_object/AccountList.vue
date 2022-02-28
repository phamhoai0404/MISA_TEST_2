<template>
<div>
    <div class="ac-list-group">
        <div class="ac-list-top">
            <div class="top-header-di">
                <div class="top-title">DANH SÁCH NHÀ CUNG CẤP</div>
                <div class="top-right">
                    <div class="group-tour">
                        <BaseButtonIcon iconClass="btn-tour" />
                        <div class="title-tour">Hướng dẫn</div>
                    </div>
                    <BaseButtonFunction label="Tiện ích" />
                    <BaseButtonFunction label="Thêm" :hasBackground="true" @btnClick="btnAddAccount" />
                </div>
            </div>
            <div class="top-header-bottom">
                <BaseButtonIcon iconClass="btn-chevron-left" :isSize16="true" />
                <a>Tất cả danh mục</a>
            </div>
        </div>
        <div class="ac-list-center">
            <BaseOverview />
        </div>
        <div class="ac-list-bottom">
            <div class="ac-list-function">
                <div class="function-left">
                    <div class="icon-check">
                        <BaseButtonIcon iconClass="btn-arrow-check-all" />
                    </div>
                    <BaseButtonFunction label="Thực hiện hàng loạt" />
                    <BaseButtonFunction label="Lọc" />
                </div>
                <div class="function-right">
                    <BaseInput typeInput="input" :hasIcon="true" placeholder="Nhập từ khóa tìm kiếm" />
                    <BaseButtonIcon iconClass="btn-refresh" title="Lấy lại dữ liệu" />
                    <BaseButtonIcon iconClass="btn-excel" title="Xuất ra excel"/>
                    <BaseButtonIcon iconClass="btn-setting-background" title="Tùy chỉnh giao diện"/>
                </div>

            </div>
            <div class="ac-list-table">
                <BaseTableList
                    height="250px"
                    :listFields = "listFieldAccount"
                    :listData ="listAccount"
                    @btnView = 'btnSeeInfoAccount'
                    @btnDropDown = 'btnDropDown'
                    @btnAllCheckbox ='btnTestAllCheckBox'
                    @btnCheckbox='btnTestCheckbox'

                    :nameTable="'AccountObject'"
                />
                <BaseTablePaging  
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
            </div>
        </div>
    </div>
     <BaseDropDownFunction v-if="isShowFunction"
        :duplicate="true"
        :remove="true"
        :edit ="true"
        :positionRight="67"
        :positionTop ="positionTopFunction"
        
        @btnClose = "btnClose"
        @btnDuplicate="btnDuplicateAccount"
        @btnRemove="btnRemoveAccount"
        @btnEdit ="btnEditAccount"
    />
<AccountDetail v-if="isShowAccountDetail" :accountTable="accountSelected" :editMode="editModeTable"/>
</div>


</template>

<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseButtonFunction from '@/components/base/BaseButtonFunction.vue'
import BaseOverview from '@/components/base/BaseOverview.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'

import BaseTableList from '@/components/base/BaseTableList.vue'
import BaseTablePaging from '@/components/base/BaseTablePaging.vue'

import BaseDropDownFunction from '@/components/base/BaseDropDownFunction.vue'

import AccountDetail from '@/view/account_object/AccountDetail.vue'

import * as mylib from '../../js/resourcs.js'
export default {
    components: {
        BaseButtonIcon,
        BaseButtonFunction,
        BaseOverview,
        BaseInput,
        BaseTableList,
        BaseTablePaging,
        BaseDropDownFunction,

        AccountDetail
    },
    mounted() {

    },
    data() {
        return {
            listFieldAccount: mylib.data.listFieldAccountObject,
            listAccount:mylib.dataTest.listAccount,
            isShowFunction:false,
            positionTopFunction:0,

            isShowPage: false,
            listPageText:mylib.data.listPageSize,
            totalRecord:0,
            pageAction:1,
            totalPage:10,
            selectTextPage: 10,

            listChecked :Array (),

            isShowAccountDetail:false,
            accountSelected:null,
            editModeTable:mylib.misaEnum.editMode.NoAction,//Mặc định đầu tiên là chưa làm gì cả

        }
    },
    watch: {

    },
    methods: {
        /**
         * Thực hiện khi click vào nút thêm trong Account List
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnAddAccount(){
            var me = this;
            me.editModeTable = mylib.misaEnum.editMode.Add;//Thực hiện thêm mới
            me.accountSelected = {};//Thực hiện gián rỗng đối tượng mới
            
            me.isShowAccountDetail = true;//Thực hiện mở form detail
            
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
        },
        /**
         * Thực hiện xem thông tin của nhà cung cấp 
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnSeeInfoAccount({object}){
            var me = this;
            me.editModeTable = mylib.misaEnum.editMode.View;//Thực hiện xem thông tin 

            me.accountSelected = object;//Thực hiện gián rỗng đối tượng mới
            me.isShowAccountDetail = true;//Thực hiện mở form detail
            
        },
         /**
         * Thực hiện khi click vào nút dropdown của mỗi dòng của function 
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnDropDown({eve, object, index }){
            var me = this;
            console.log(index);
            me.accountSelected = object;//Gián giá trị đối tượng dòng đang chọn vào đối tượng đang chờ để thực hiện thao tác

            //Thực hiện truyền tọa độ thích hợp cho dropdown 
            me.positionTopFunction = eve.clientY < 500 ? (eve.clientY + 14) : (eve.clientY - 105);
            me.isShowFunction = true;
            
        },
        btnDuplicateAccount(){
            alert("Duplicate");
        },
        btnRemoveAccount(){
            alert("Remove");
        },
         /**
         * Thực hiện khi click vào nút sửa trong dropdown 
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnEditAccount(){
            var me  = this;
            me.editModeTable = mylib.misaEnum.editMode.Edit;//Thực hiện Sửa thông tin

            me.isShowAccountDetail = true;//Mở form detail
        },
        btnClose(){
            var me = this;
            if(me.isShowFunction == true){
                me.isShowFunction = false;
            }
        },
        changeValue(newValue){
            var me = this;
            me.testRadio = newValue;
        },
        btnCheckboxTest({id}){
            console.log("is", id);
        },
        btnTestAllCheckBox({id}){
            console.log("all", id);
        },
        btnTestCheckbox({id}){
            console.log("cuộc đời cong");
            console.log("item", id);
            const item = document.getElementById(id);
            console.log(item.checked);
            this.listChecked.push(id);
            console.log(this.listChecked);
        },
        clickTest(){
            alert("hoa");
        }
    },
}
</script>

<style scoped>
@import url(../../style/view/account_object/account-list.css);
</style>
