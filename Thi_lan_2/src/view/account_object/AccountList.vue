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
                    <BaseInput typeInput="input" :hasIcon="true" placeholder="Nhập từ khóa tìm kiếm" v-model="keywordSearch"/>
                    <BaseButtonIcon iconClass="btn-refresh" title="Lấy lại dữ liệu"  @btnClick="showData"/>
                    <BaseButtonIcon iconClass="btn-excel" title="Xuất ra excel" @btnClick="btnExportExcel"/>
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
        
        @hideFunction ="isShowFunction = false"
        @btnDuplicate="btnDuplicateAccount"
        @btnRemove="btnRemoveAccount"
        @btnEdit ="btnEditAccount"
    />
<AccountDetail v-if="isShowAccountDetail" :accountTable="accountSelected" :editMode="editModeTable"/>
<BaseLoading v-if="isShowLoading"/>
<BaseMessageRemove  v-if="isShowMessRemove" 
    typeMessage="warningAndQuestion" 
    :titleForm="titleMessRemove"
    @btnNo="isShowMessRemove = false"
    @btnYes="btnConfirmRemove"
/>
<BaseMessageInfo v-if="isShowMessInfo" 
    typeMessage="info" 
    :titleForm="titleMessInfo"
    @btnClose="isShowMessInfo = false"
/>
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

import BaseLoading from '@/components/base/BaseLoading.vue'
import BaseMessageRemove from '@/components/base/BaseMessage.vue'
import BaseMessageInfo from '@/components/base/BaseMessage.vue'

import * as mylib from '../../js/resourcs.js'
import axios from 'axios'
export default {
    components: {
        BaseLoading,
        BaseButtonIcon,
        BaseButtonFunction,
        BaseOverview,
        BaseInput,
        BaseTableList,
        BaseTablePaging,
        BaseDropDownFunction,
        BaseMessageRemove,
        BaseMessageInfo,

        AccountDetail
    },
    mounted() {

    },
    created(){
        var me = this;
        me.getData();
    },
    data() {
        return {
            isShowLoading:false,//Mặc định là đang đóng loading

            listFieldAccount: mylib.data.listFieldAccountObject,
            listAccount:null,//Dùng để lưu trữ list Employee
            isShowFunction:false,
            positionTopFunction:0,

            isShowPage: false,
            listPageText:mylib.data.listPageSize,
            totalRecord:0,
            pageAction:1,
            totalPage:10,
            selectTextPage: 20,

            listChecked :Array (),

            isShowAccountDetail:false,
            accountSelected:null,
            editModeTable:mylib.misaEnum.editMode.NoAction,//Mặc định đầu tiên là chưa làm gì cả

            keywordSearch:"",//Từ khóa tìm kiếm trong ô input

            titleMessInfo:mylib.resourcs["VI"].titleErrorRemoveAccountObject,
            titleMessRemove:null,
            isShowMessRemove:false,
            isShowMessInfo:false,
        }
    },
    watch: {
        /*Thực hiện theo dõi biến để load lại trang mong muốn đang làm
        *CreatedBy: HoaiPT(01/03/2022)
        */
        keywordSearch: function () {
            var me = this;
            clearTimeout(me.myTimeout);
            me.myTimeout = setTimeout(function () {
                me.pageAction = 1;//Thực hiện chuyển về trang đầu tiên
                me.showData();//Lấy lại dữ liệu
            }, 1000);
        }
    },
    methods: {
       
        
       
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
      
        
         /**
         * Thực hiện khi click vào nút sửa trong dropdown 
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnEditAccount(){
            var me  = this;
            me.editModeTable = mylib.misaEnum.editMode.Edit;//Thực hiện Sửa thông tin
            me.isShowFunction = false;
            me.isShowAccountDetail = true;//Mở form detail
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
        },

        
         /**
         * Thực hiện khi click vào nút xác nhận xóa
         * CreatedBy: HoaiPT(01/03/2022)
         */
        btnConfirmRemove(){
            try {
                var me = this;
                 axios.delete(`https://localhost:44338/api/v1/AccountObjects/${this.accountSelected.AccountObjectId}`)
                .then(function () {          
                    //Đóng form
                    me.isShowMessRemove = false;//Đóng form xóa
                    me.getData();//Thực hiện load lại dữ liệu
                })
                .catch(function () {
                    //Trường hợp lỗi không xóa được thông tin lỗi đã ghi ở resource ở chỗ data return rồi
                    me.isShowMessRemove = false;//Thực hiện đóng form xóa

                    //Thực hiện mở form thông báo lỗi
                    me.isShowMessInfo = true;
                })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện khi click vào nút xóa trong td
         * CreatedBy: HoaiPT(01/03/2022)
         */
        btnRemoveAccount(){    
            var me = this;
            me.isShowFunction = false;//Đóng dropdown function
            me.titleMessRemove = `Bạn có thực sự muốn xóa Nhà cung cấp <${me.accountSelected.AccountObjectCode}> không?`;
            me.isShowMessRemove = true;//Thực hiện mở form remove
        },
        /**
         * Thực hiện khi click vào nút nhân bản trong dropdown
         * CreatedBy: HoaiPT(01/03/2022)
         */
        async btnDuplicateAccount(){
            var me = this;
            me.isShowFunction = false;//Thực hiện đóng function
            me.editModeTable = mylib.misaEnum.editMode.Add;//Thực hiện thêm mới

            //AccountObject thì bằng cái lúc mà click vào nút dropdown rồi đó là me.accountSelected  ấy
            await me.getCodeNew();//Thực hiện lấy ra mã mới

            me.isShowAccountDetail = true;//Thực hiện mở form detail
        },
         /**
         * Thực hiện khi click vào nút thêm trong Account List
         * CreatedBy: HoaiPT(28/02/2022)
         */
        async btnAddAccount(){
            var me = this;
            me.editModeTable = mylib.misaEnum.editMode.Add;//Thực hiện thêm mới
            me.accountSelected = {};//Thực hiện gián rỗng đối tượng mới
           
           await me.getCodeNew();//Thực hiện lấy ra mã mới

            me.isShowAccountDetail = true;//Thực hiện mở form detail
            
        },
        /**
         * Thực hiện khi click vào kích thước trang mong muốn
         * UpdateBy: HoaiPT(01/03/2022)
         */
        async selectedPageText({index}){
            var me = this;
            me.selectTextPage = me.listPageText[index]; //Thực hiện gán số kích thước trang đã lựa chọn 
            me.pageAction = 1;//Chuyển về trang đầu tiên
            me.isShowPage = false; //Đóng form page
            
            await me.showData();
        },
        /**
         * Thực hiện khi click vào nút mở kích thước trang
         * UpdateBy: HoaiPT(01/03/2022)
         */
        btnSelectPage(){
            var me =this;
            me.isShowPage = !me.isShowPage;
        },
        /**
         * Thực hiện khi click vào trang mong muốn
         * UpdateBy: HoaiPT(01/03/2022)
         */
        async clickCallback({number}){
            var me = this;
            me.pageAction = number;
            await me.showData();
        },
        /**
         * Lấy toàn bộ dữ liệu về trạng thái ban đầu
         * CreatedBy: HoaiPT(17/02/2022)
         * UpdateBy: HoaiPT(01/03/2022)
         */
        getData() {
            //Chắc chắn là con trỏ this đang ở đây;
            var me = this;
            me.selectTextPage = 20; //Reset lại số lượng bản ghi trên 1 trang 
            me.pageAction = 1; //Reset lại số trang  đang hiển thị

            me.keywordSearch = "";
            me.showData(); //Load dữ liệu
        },
        /**
         * Lấy và gán dữ liệu dữ liệu
         * CreatedBy: HoaiPT(17/02/2022)
         * UpdateBy: HoaiPT(01/03/2022)
         */
        async showData() {
            try {
                var me = this;
                me.isShowLoading = true; //Thực hiện mở Loading
                await axios.get(`https://localhost:44338/api/v1/AccountObjects/getPaging?searchText=${me.keywordSearch}&pageIndex=${me.pageAction}&pageSize=${me.selectTextPage}`)
                    .then(function (res) {
                        me.listAccount = res.data.Data; //Thực hiện gián listEmployee vào với kích thước trang, từ khóa tìm kiếm và trang đang đứng
                        me.totalPage = Number(res.data.TotalPage); //Gán vào tổng số trang
                        me.totalRecord = res.data.TotalRecord; //Gán vào tổng số bản ghi
                        me.isShowLoading = false; //Đóng loading
                    })
                    .catch(function (res) {
                        console.log(res);
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện export Excel
         * CreatedBy: HoaiPT(14/02/2022)
         * UpdateBy: HoaiPT(01/03/2022)
         */
        btnExportExcel() {
            try {
                //Chắc chắn là con trỏ this đang ở đây;
                var me = this;
                me.isShowLoading = true; //Hiển thị đang load
                axios.get('https://localhost:44338/api/v1/AccountObjects/Excel', {
                    responseType: 'blob',
                }).then((response) => {
                    const url = URL.createObjectURL(new Blob([response.data]));
                    const link = document.createElement('a'); //Tạo ra một element mới là thẻ a
                    link.href = url; //Thẻ a này có đường dẫn là file excel trả về từ database
                    link.setAttribute(
                        'download',
                        `${mylib.resourcs["VI"].fileNameAccountObjectExport}-${new Date().toLocaleDateString()}.xlsx` //File excel tải về có dạng như vậy
                    )
                    document.body.appendChild(link); //Thêm đường link mới này vào trong file html
                    link.click();
                    me.isShowLoading = false; //Đóng Loading
                })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện lấy mã code mới tự sinh
         * CreatedBy: HoaiPT(15/02/2022)
         * UpdateBy: HoaiPT(01/03/2022)
         */
        async getCodeNew() {
            try {
                var me = this;
                me.isShowLoading = true; //Hiển thị đang load
                await axios.get('https://localhost:44338/api/v1/AccountObjects/CodeNew')
                    .then(function (res) {
                        me.accountSelected.AccountObjectCode = res.data;//Gán mã mới
                        me.isShowLoading = false; //đóng load
                    })
                    .catch(function (res) {
                        console.error(res);
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
    },
}
</script>

<style scoped>
@import url(../../style/view/account_object/account-list.css);
</style>
