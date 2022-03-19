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
                    <BaseButtonFunction label="Thực hiện hàng loạt" styleButton="max-width: 183px !important;min-width: 183px !important " @btnClick="isShowRemoveMany=!isShowRemoveMany"/>
                    <div v-if="listCaPaymentRemove.length >0 && isShowRemoveMany == true" class="delete-many">
                        <div @click="btnRemoveMany">Xóa</div> 
                    </div>
                    <BaseButtonFunction label="Lọc" styleButton='margin-left:10px; margin-right: 10px; width: 78px !important;' @btnClick="btnClickFilterList"/>
                    <div class="group-filter">
                        <div v-if="exitObjectFilter()" class="item-filter" >
                            <span>
                                <div class="item-title" >{{formatDate(objectFilter.StartTime)}} - {{formatDate(objectFilter.EndTime)}} </div>
                                <BaseButtonIcon iconClass="btn-close-small" :isSize16="true" styleButtonIcon="margin-left:3px;" @btnClick="btnRemoveAllFilter"/>
                            </span>
                        </div>
                        <div  v-if="exitObjectFilter()" class="item-filter" >
                            <span>
                                <div class="item-title" @click="btnRemoveAllFilter" >Xóa bộ lọc</div>
                            </span>
                        </div>
                    </div>
                    <div class="dropdown-filter" style="margin-top: 333px; width: 454px !important;" v-if="isShowFilterCaPayment" >
                        <div class="row-one">
                            <BaseComboboxNormal v-model="objectFilterTemp.Type" label="Lý do thu, chi" :datas="[]" title="Lý do thu, chi"/>
                        </div>
                        <div class="row-one" style="padding-top: 10px;">
                            <BaseComboboxNormal v-model="objectFilterTemp.Type" label="Trạng thái ghi sổ" :datas="[]" title="Trạng thái ghi sổ"/>
                        </div>
                        <div class="row-two" style="padding-top: 10px;">
                            <div style="width: 32%">
                                <BaseComboboxNormal  label="Thời gian" styleDataCombobox="max-height:90px !important;"
                                    :isComboboxTable = "true"
                                    :showField="false"
                                    v-model="objectFilterTemp.DateTimeName"
                                    :errorCombobox="errorDateTime"
                                    :title="titleDateTime"

                                    :listFields="listFieldDataTime"
                                    :datas="listDataTimeSource"

                                    inputText="DateTimeName"
                                    :propertyCompare="objectFilterTemp.DateTimeId"
                                    keySearch="DateTimeId"

                                    @onChangeValueKeySearch ="changeIdDateTime"
                                    @input="changeInputDateTime"
                                />
                            </div>
                             <div style="width: 32%">
                                <BaseInput typeInput="date" label="Từ ngày" 
                                    v-model="objectFilterTemp.StartTime"
                                    :errorInput="errorStartTime"
                                    :title="titleStartTime"
                                    @inputChange="changeInputStartTime"
                                    @input="changeInputStartTime"
                                    ref="StartTime"
                                />
                            </div>
                            <div style="width: 32%">
                                <BaseInput typeInput="date" label="Đến ngày" 
                                    v-model="objectFilterTemp.EndTime"
                                    :errorInput="errorEndTime"
                                    :title="titleEndTime"
                                    @inputChange="changeInputEndTime"
                                    @input="changeInputEndTime"
                                    ref="EndTime"
                                />
                            </div>
                        </div>
                        <div class="line-dropdown-filter"></div>
                        <div class="row-two">
                            <BaseButton label="Đặt lại" @btnClick="btnClickResetFilter"/>
                            <BaseButton label="Lọc" :hasBackground="true" @btnClick="btnClickFilterInDropdown"/>
                        </div>    
                    </div>
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

                    @btnCheckbox='btnCheckboxItem'
                    
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
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import BaseTableList from '@/components/base/BaseTableList.vue'
import BaseTablePaging from '@/components/base/BaseTablePaging.vue'
import BaseButton from '@/components/base/BaseButton.vue'
import CAPaymentDetail from '@/view/cash/CAPaymentDetail.vue'

import BaseMessageRemove from '@/components/base/BaseMessage.vue'

import * as mylib from '../../js/resourcs.js'
import axios from 'axios'
import MyFunction from '@/js/function.js'

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
        BaseMessageRemove,
        BaseButton,
        BaseComboboxNormal
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
            isShowFunction:false,//Đóng mở function dropdown

            editModeTable:mylib.misaEnum.editMode.NoAction,//Mặc định đầu tiên là chưa làm gì cả

            positionTopFunction:0,//Vị trí của của dropdown Function

            isShowDetailCaPayment:false,//Biến đóng mở của detail
            idCaPaymentSelected:"",//Nơi lưu trữ id,
            objectCaPayment:{},//Nơi lưu trữ object

            isShowMessRemove:false,//Trạng thái của form xóa
            titleMessRemove:"",//title hiện thị mong muốn

            isShowFilterCaPayment:false,
            objectFilterTemp:{
                Type:"Tất cả",
                DateTimeId:"0",
                DateTimeName:"Tùy chọn",
                StartTime: null,
                EndTime:null,
            },
            objectFilter:{
                StartTime: null,
                EndTime:null,
            },//bộ lọc thật sự

            errorStartTime:false,//Có lỗi hay không của ngày bắt đầu
            titleStartTime:"",//Title hiển thị khi có báo lỗi
            errorEndTime:false,//Có lỗi hay không của ngày kết thúc
            titleEndTime:"",//Title hiển thị khi có báo lỗi
            listDataTimeSource:mylib.dataSource.listDateTimeFilter,//Nguồn của DataTime
            listFieldDataTime:mylib.data.listFieldDateTimeFilter,//File data hiển thị của DataTime
            errorDateTime:false,//Có lỗi hay không của ô thời gian
            titleDateTime:"",//Title có hiển thị khi lỗi DateTime hay không

             //Mảng dùng để lưu trữ toàn id xóa
            listCaPaymentRemove:new Array(),
            isShowRemoveMany:false,
            actionDelete:mylib.misaEnum.actionDelete.NoAction,//Đầu tiên là không thực hiện xóa gì
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
        btnRemoveMany(){
            var me = this;
            me.isShowRemoveMany = false;//Thực hiện đóng xóa nhiều dropdown

            me.actionDelete = mylib.misaEnum.actionDelete.Multi;//Thực hiện xóa nhiều

            me.titleMessRemove = 'Bạn có thực sự muốn xóa những phiếu chi này không?';//Thể hiện title mong muốn
            me.isShowMessRemove = true;//Hiển thị xóa nhiều message
        },
         /**
         * Thực hiện click vào checkbox
         * CreatedBy: HoaiPT(19/03/2022)
         */
        btnCheckboxItem({id}){
            const item = document.getElementById(id);
            if(item.checked == true){
                this.listCaPaymentRemove.push(id);
            }else{
                this.listCaPaymentRemove = this.listCaPaymentRemove.filter(item => item != id)
            }
            console.log(this.listCaPaymentRemove);
        },
        /**
         * Thực hiện khi thay đổi giá trị input nhập vào ấy
         * CreatedBy: HoaiPT(19/03/2022)
         */
        changeInputDateTime(){
            this.objectFilterTemp.DateTimeId = null;
        },
        /*
         * Thực hiện khi thay đổi giá trị input nhập vào ấy
         * CreatedBy: HoaiPT(19/03/2022)
         */
        changeIdDateTime(object){
            this.objectFilterTemp.DateTimeId = object.DateTimeId;
            switch (object.DateTimeId) {
                case "0"://1 ở tùy chọn thì không phải làm gì hết
                    break;
                case "1"://Tuần này
                    var curr = new Date();
                    var first = curr.getDate() - curr.getDay() + 1; 
                    var last = first + 6;
                    var firstday = new Date(curr.setDate(first)).toUTCString();
                    var lastday = new Date(curr.setDate(last)).toUTCString();
                    this.objectFilterTemp.StartTime = firstday;
                    this.objectFilterTemp.EndTime = lastday;

                    break;
                case "2"://Tháng này
                    var date = new Date();
                    var firstDay2 = new Date(date.getFullYear(), date.getMonth(), 1);
                    var lastDay2 = new Date(date.getFullYear(), date.getMonth() + 1, 0);
                    this.objectFilterTemp.StartTime = firstDay2;
                    this.objectFilterTemp.EndTime = lastDay2;

                    break;
                case "3"://Tháng 4
                    var date4 = new Date();
                    var firstDay4 = new Date(date4.getFullYear(), 3, 1);
                    var lastDay4 = new Date(date4.getFullYear(), 3 + 1, 0);
                    this.objectFilterTemp.StartTime = firstDay4;
                    this.objectFilterTemp.EndTime = lastDay4;
                    break;
                default:
                    break;
            }

            //Nếu có viền đỏ thì thực hiện xóa viền đỏ của StartTime and EndTime
            this.errorEndTime=false;
            this.titleEndTime="";
            this.errorStartTime = false;
            this.titleEndTime ="";
        },
        /**
         * Thực hiện khi click vào xóa bộ lọc của filter CaPayment
         * CreatedBy: HoaiPT(19/03/2022)
         */
        async btnRemoveAllFilter(){
            let objectTemp= {};//Thực hiện gián tất cả bằng null 
            this.objectFilter = MyFunction.sameObjectDestination(this.objectFilter, objectTemp);//làm ở function ấy
            
            await this.showData();//Load lại dữ liệu
        },
        /**
         * Thực hiện kiểm tra xem có bộ lọc hay không nếu không tồn tại thì không có chữ hiện thị
         * CreatedBy: HoaiPT(19/03/2022)
         */
        exitObjectFilter(){
            if(this.objectFilter.EndTime !=null)//Chỉ cần kiểm tra một cái thôi còn cái kia nó dính với cái này
                return true;
            return false;
        },
        btnClickResetFilter(){
            console.log("vào đây");
            this.objectFilterTemp.DateTimeId = "0";
            this.objectFilterTemp.DateTimeName="Tùy chọn";
            this.objectFilterTemp.EndTime = null;
            this.objectFilterTemp.StartTime = null;

            //Nếu có viền đỏ thì thực hiện xóa viền đỏ của StartTime and EndTime
            this.errorEndTime=false;
            this.titleEndTime="";
            this.errorStartTime = false;
            this.titleEndTime ="";
        },
        /**
         * Thực hiện khi bắt đầu click vào nút lọc của dropdown Filter
         * CreatedBy: HoaiPT(19/03/2022)
         */
        async btnClickFilterInDropdown(){
            var me = this;
            if( !me.validateStartTimeAndEndTime()){
                return;
            }
            this.objectFilter = MyFunction.sameObjectDestination(this.objectFilter, this.objectFilterTemp);
            this.isShowFilterCaPayment = false;//Thực hiện đóng lọc

            await me.showData();
        },
         /**
         * Thực hiện valiate StartTime and EndTime
         * CreatedBy: HoaiPT(19/03/2022)
         */
        validateStartTimeAndEndTime(){
            var me = this;
            if(me.objectFilterTemp.StartTime == null){
                me.errorStartTime = true;
                me.titleStartTime = mylib.resourcs["VI"].notNullStartTime;
                me.$refs.StartTime.focus();

                return false;
            }

            if(me.objectFilterTemp.EndTime == null){
                me.errorEndTime = true;
                me.titleEndTime = mylib.resourcs["VI"].notNullEndTime;
                me.$refs.EndTime.focus();

                return false;
            }

            //EndTime >= StartTime
            let tempEndTime = new Date(me.objectFilterTemp.EndTime);
            let tempStartTime = new Date(me.objectFilterTemp.StartTime);
            if(tempEndTime < tempStartTime){
                me.titleEndTime = mylib.resourcs['VI'].errorEndTimeLessStartTime;
                me.errorEndTime = true;//Xuất hiện viền đỏ của đến ngày
                
                me.$refs.EndTime.focus();

                return false;
            }

            return true;//Thông qua
        },
        /**
         * Nếu có viền đỏ khi thay đổi input thì viền đỏ biến mất
         * CreatedBy: HoaiPT(19/03/2022)
         */
        changeInputEndTime(){
            var me = this;
            me.errorEndTime = false;
            me.titleEndTime ="";

            //Chỉ cần thực hiện thay đổi input là đưa về tùy chọn
            me.objectFilterTemp.DateTimeName="Tùy chọn";
            me.objectFilterTemp.DateTimeId ="0";
        },
         /**
         * Nếu có viền đỏ khi thay đổi input thì viền đỏ biến mất
         * CreatedBy: HoaiPT(19/03/2022)
         */
        changeInputStartTime(){
            var me = this;
            me.errorStartTime = false;
            me.titleStartTime ="";
            
            //Chỉ cần thực hiện thay đổi input là đưa về tùy chọn
            me.objectFilterTemp.DateTimeName="Tùy chọn";
            me.objectFilterTemp.DateTimeId ="0";
        },
        /**
         * Thực hiện khi bắt đầu click vào nút lọc của table list
         * CreatedBy: HoaiPT(19/03/2022)
         */
        btnClickFilterList(){
            this.isShowFilterCaPayment = !this.isShowFilterCaPayment;//Nếu đóng thì mở nếu mở thì đóng khi click vào chữ lọc ở list
        },
        /**
         * Thực hiện khi click vào nút thêm chi tiết phiếu chi
         * CreatedBy: HoaiPT(11/03/2022)
         */
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
                let tempListCaPaymentRemove = me.listCaPaymentRemove;
                MyFunction.removeChecked(me.listCaPaymentRemove);//Thực hiện bỏ checked
                me.listCaPaymentRemove =[];//Làm mới rỗng

                switch (me.actionDelete) {
                    case mylib.misaEnum.actionDelete.One:
                        axios.delete(`https://localhost:44338/api/v1/ControlCaPayment/${this.idCaPaymentSelected}`)
                        .then(function () {          
                            //Đóng form
                            me.isShowMessRemove = false;//Đóng form xóa
                            me.getData();//Thực hiện load lại dữ liệu
                        })
                        .catch(function () {
                            console.log(mylib.resourcs["VI"].errorMsg);
                        })
                        break;
                    case mylib.misaEnum.actionDelete.Multi:
                        console.log(tempListCaPaymentRemove);
                        console.log("Thực hiện xóa nhiều");
                        break;
                    default:
                        break;
                }
                 
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
            me.isShowRemoveMany = false;//Thực hiện đóng xóa nhiều nếu mở

            me.actionDelete = mylib.misaEnum.actionDelete.One;//Thực hiện xóa 1;

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
                await axios.post(`https://localhost:44338/api/v1/CaPayments/GetPageV2?searchText=${me.keywordSearch}&pageIndex=${me.pageAction}&pageSize=${me.selectTextPage}`, me.objectFilter)
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
        formatDate:MyFunction.formatDate,
    },
}
</script>