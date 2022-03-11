<template>
    <div class="ac-list-group">
        <div class="ac-list-top" style="padding-bottom: 0px; max-height:50px; padding-top:15px;">
            <div class="top-header-di" >
                <div class="top-title">THU CHI TIỀN MẶT</div>
                <div class="top-right" style="min-width:280px !important;">
                    <div class="group-tour">
                        <BaseButtonIcon iconClass="btn-tour" />
                        <div class="title-tour">Hướng dẫn</div>
                    </div>
                    <BaseButtonFunction label="Thêm chi tiền" :hasBackground="true" @btnClick="btnAddCaPayment" />
                </div>
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
                    <BaseInput typeInput="input" :hasIcon="true" placeholder="Nhập từ khóa tìm kiếm" v-model="keywordSearch" />
                    <BaseButtonIcon iconClass="btn-refresh" title="Lấy lại dữ liệu"  @btnClick="showData" />
                    <BaseButtonIcon iconClass="btn-excel" title="Xuất ra excel"  @btnClick="btnExportExcel"/>
                    <BaseButtonIcon iconClass="btn-setting-background" title="Tùy chỉnh giao diện"/>
                </div>

            </div>
            <div class="ac-list-table">
                 <BaseTableList
                    height="235px"
                    :hasFooterTable="true"
                    :nameTable="'CaPayment'"

                    :listFields ="listFieldCAPayment"
                    :listData ="listCAPayment"
                    
                    @btnView ='btnSeeInfoCAPayment'
                    @btnDropDown ='btnDropDown'
                    
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
<BaseLoading v-if="isShowLoading"/>
<BaseDropDownFunction v-if="isShowFunction"
    :unpin="true"
    :remove="true"
    :duplicate="true"
    :positionRight="67"
    :positionTop ="positionTopFunction"
    
    @hideFunction ="isShowFunction = false"
    @btnDuplicate="btnDuplicateCaPayment"
    @btnRemove="btnRemoveCaPayment"
/>
<BaseMessageRemove  v-if="isShowMessRemove" 
    typeMessage="warningAndQuestion" 
    :titleForm="titleMessRemove"
    @btnNo="isShowMessRemove = false"
    @btnYes="btnConfirmRemove"
/>
<CAPaymentDetail v-if="isShowDetailCaPayment" :editMode="editModeTable" :idCaPayment="idCaPaymentSelected"/>
</div>

</template>
<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseButtonFunction from '@/components/base/BaseButtonFunction.vue'
import BaseOverview from '@/components/base/BaseOverview.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'
import BaseLoading from '@/components/base/BaseLoading.vue'
import BaseDropDownFunction from '@/components/base/BaseDropDownFunction.vue'

import BaseTableList from '@/components/base/BaseTableList.vue'
import BaseTablePaging from '@/components/base/BaseTablePaging.vue'

import CAPaymentDetail from '@/view/cash/CAPaymentDetail.vue'

import BaseMessageRemove from '@/components/base/BaseMessage.vue'

import * as mylib from '../../js/resourcs.js'
import axios from 'axios'
export default {
    components:{
        BaseButtonFunction,
        BaseButtonIcon,
        BaseOverview,
        BaseInput,
        BaseTableList,
        BaseTablePaging,
        BaseLoading,
        BaseDropDownFunction,
        CAPaymentDetail,
        BaseMessageRemove
    },
    data() {
        return {
            listCAPayment:[],
            listFieldCAPayment:mylib.data.listFieldCAPayment,

            isShowLoading:false,//Biến dùng để dẩn hiện loading

            isShowPage: false,
            listPageText:mylib.data.listPageSize,
            totalRecord:0,
            pageAction:1,//Mặc định là trang đầu tiên
            totalPage:1,
            selectTextPage: 20,//Mặc định ban đầu kích thước là 20 bản ghi trên một trang

            keywordSearch:"",//Từ khóa tìm kiếm,
            objectSearch:{},
            isShowFunction:false,//Đóng mở function dropdown

            editModeTable:mylib.misaEnum.editMode.NoAction,//Mặc định đầu tiên là chưa làm gì cả

            positionTopFunction:0,//Vị trí của của dropdown Function

            isShowDetailCaPayment:false,//Biến đóng mở của detail
            idCaPaymentSelected:"",//Nơi lưu trữ id,
            objectCaPayment:{},//Nơi lưu trữ object

            isShowMessRemove:false,//Trạng thái của form xóa
            titleMessRemove:"",//title hiện thị mong muốn
        }
    },
    watch:{
        /*Thực hiện theo dõi biến để load lại trang mong muốn đang làm
        *CreatedBy: HoaiPT(11/03/2022)
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
    created(){
        var me = this;
        me.getData();//Trạng thái ban đầu
    },
    methods: {
        btnAddCaPayment(){
            var me =this; 
            me.editModeTable = mylib.misaEnum.editMode.Add;//Thực hiện thêm mới
            me.isShowDetailCaPayment = true;
        },
        /**
         * Thực hiện khi click vào nút xác nhận xóa
         * CreatedBy: HoaiPT(11/03/2022)
         */
        btnConfirmRemove(){
             try {
                var me = this;
                 axios.delete(`https://localhost:44338/api/v1/ControlCaPayment/${this.idCaPaymentSelected}`)
                .then(function () {          
                    //Đóng form
                    me.isShowMessRemove = false;//Đóng form xóa
                    me.getData();//Thực hiện load lại dữ liệu
                })
                .catch(function () {
                    console.log(mylib.resourcs["VI"].errorMsg);
                })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện khi click vào nút xóa trong dropdown function
         * CreatedBy: HoaiPT(11/03/2022)
         */
        btnRemoveCaPayment(){
            var me = this;
            me.isShowFunction = false;//Đóng dropdown function
            me.titleMessRemove = `Bạn có muốn xóa chứng từ <${me.objectCaPayment.CaPaymentNo}> không?`;
            me.isShowMessRemove = true;//Thực hiện mở form remove
        },
        btnDuplicateCaPayment(){
            var me = this;
            me.isShowFunction = false;//Đóng dropdown function
            me.editModeTable = mylib.misaEnum.editMode.Duplicate;//Thực hiện nhân bản

            me.isShowDetailCaPayment = true;
        },
        /**
         * Thực hiện khi click vào nút xem
         * CreatedBy: HoaiPT(11/03/2022)
         */
        btnSeeInfoCAPayment({object}){
            var me = this;
            me.editModeTable = mylib.misaEnum.editMode.View;//Thực hiện xem thông tin

            me.idCaPaymentSelected = object.CaPaymentId;
            me.isShowDetailCaPayment = true;
        },
         /**
         * Thực hiện khi click vào nút dropdown của mỗi dòng của function 
         * CreatedBy: HoaiPT(11/03/2022)
         */
        btnDropDown({eve, object, index }){
            var me = this;
            console.log(index);

            me.objectCaPayment = object;
            me.idCaPaymentSelected = object.CaPaymentId;

            //Thực hiện truyền tọa độ thích hợp cho dropdown 
            me.positionTopFunction = eve.clientY < 500 ? (eve.clientY + 14) : (eve.clientY - 105);
            me.isShowFunction = true;
            
        },
         /**
         * Thực hiện khi click vào kích thước trang mong muốn
         * UpdateBy: HoaiPT(11/03/2022)
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
         * UpdateBy: HoaiPT(11/03/2022)
         */
        btnSelectPage(){
            var me =this;
            me.isShowPage = !me.isShowPage;
        },
        /**
         * Thực hiện khi click vào trang mong muốn
         * UpdateBy: HoaiPT(11/03/2022)
         */
        async clickCallback({number}){
            var me = this;
            me.pageAction = number;
            await me.showData();
        },
        /**
         * Lấy toàn bộ dữ liệu về trạng thái ban đầu
         * CreatedBy: HoaiPT(11/03/2022)
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
         * CreatedBy: HoaiPT(11/03/2022)
         */
        async showData() {
            try {
                var me = this;
                me.isShowLoading = true; //Thực hiện mở Loading
                await axios.post(`https://localhost:44338/api/v1/CaPayments/GetPageV2?searchText=${me.keywordSearch}&pageIndex=${me.pageAction}&pageSize=${me.selectTextPage}`, me.objectSearch)
                    .then(function (res) {
                        me.listCAPayment = res.data.Data; //Thực hiện gián listEmployee vào với kích thước trang, từ khóa tìm kiếm và trang đang đứng
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
         * CreatedBy: HoaiPT(11/03/2022)
         */
        btnExportExcel() {
            try {
                //Chắc chắn là con trỏ this đang ở đây;
                var me = this;
                me.isShowLoading = true; //Hiển thị đang load
                axios.get('https://localhost:44338/api/v1/CaPayments/Excel', {
                    responseType: 'blob',
                }).then((response) => {
                    const url = URL.createObjectURL(new Blob([response.data]));
                    const link = document.createElement('a'); //Tạo ra một element mới là thẻ a
                    link.href = url; //Thẻ a này có đường dẫn là file excel trả về từ database
                    link.setAttribute(
                        'download',
                        `${mylib.resourcs["VI"].fileNameCaPaymentExport}-${new Date().toLocaleDateString()}.xlsx` //File excel tải về có dạng như vậy
                    )
                    document.body.appendChild(link); //Thêm đường link mới này vào trong file html
                    link.click();
                    me.isShowLoading = false; //Đóng Loading
                })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
    },
}
</script>