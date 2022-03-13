<template>
<div class="popup-detail" >
    <div class="popup-top-header">
        <div class="top-header-left">
            <BaseButtonIcon iconClass="btn-clock" />
            <div class="title-top-header-left">Phiếu chi {{caPayment.CaPaymentNo}}</div>
            <div style="padding-left:24px;">
                <BaseComboboxNormal v-model="titlePopupDefault" :datas="[]" styleComboboxNormal="width:350px;" :readOnly="readOnly" />
            </div>
        </div>
        <div class="top-header-right">
            <div class="item-button">
                <BaseButtonIcon iconClass="btn-tour" />
            </div>
            <a class=title-top-header>Hướng dẫn</a>
            <div class="item-button">
                <BaseButtonIcon iconClass="btn-setting-normal" />
            </div>
            <div class="item-button">
                <BaseButtonIcon iconClass="btn-icon-help" />
            </div>
            <div class="item-button">
                <BaseButtonIcon iconClass="btn-icon-close" @btnClick="btnCloseToolTip"/>
            </div>
        </div>
    </div>
    <div class="popup-content" v-if="isShowDetail">
        <div class="content-master">
            <div class="popup-content-left">
                <div class="master-left-one">
                    <div class="left-row-multi">
                        <div style="width:40%; padding-right: 12px;">
                            <BaseComboboxNormal  label="Đối tượng" :isButtonAdd="true" styleDataCombobox="width: 880px;"

                                v-model="caPayment.AccountObjectName"
                                :isComboboxTable="true"
                                :readOnly="readOnly"

                                :listFields="lisFieldAccountObject"
                                :datas="listAccountObject" 

                                inputText="AccountObjectName"
                                :propertyCompare="caPayment.AccountObjectId"
                                keySearch="AccountObjectId"
                                ref="AccountObject"
                            />
                        </div>
                        <div style="width:59%;">
                            <BaseInput typeInput="input" label="Người nhận"  v-model="caPayment.Receiver" :readOnly="readOnly" />
                        </div>
                    </div>
                    <div class="left-row">
                        <BaseInput typeInput="input" label="Địa chỉ" v-model="caPayment.Address" :readOnly="readOnly" />
                    </div>
                    <div class="left-row">
                        <BaseInput typeInput="input" label="Lý do"  v-model="caPayment.Resion" :readOnly="readOnly" />
                    </div>
                    <div class="left-row-multi">
                        <div style="width:40%; padding-right: 12px;">
                            <BaseComboboxNormal :isButtonAdd="true" label="Nhân viên" styleDataCombobox="width: 880px;"
                                v-model="caPayment.FullName"
                                :isComboboxTable="true"
                                :readOnly="readOnly"

                                :listFields="listFieldEmployee" 
                                :datas="listEmployee"
            
                                inputText="FullName"
                                :propertyCompare="caPayment.EmployeeId"
                                keySearch="EmployeeId" 
                            />
                        </div>
                        <div style="width:59%; display: flex;">
                            <BaseInput typeInput="input" label="Kèm theo" :isNumber="true" placeholder="Số lượng" styleInput="width: 40%;"  v-model="caPayment.AttachNumber" :readOnly="readOnly"/>
                            <div style="padding: 28px 6.5px 0;">Chứng từ gốc</div>
                        </div>
                    </div>
                    <div class="left-row-multi">
                        <div>Tham chiếu</div>
                        <div class="cetera">...</div>
                    </div>
                </div>
                <div class="master-left-two" style="width:185px;">
                    <div class="item-left-two">
                        <BaseInput typeInput="date" label="Ngày hạch toán" v-model="caPayment.PostedDate" :readOnly="readOnly" />
                    </div>
                    <div class="item-left-two">
                        <BaseInput typeInput="date" label="Ngày phiếu chi" v-model="caPayment.CaPaymentDate" :readOnly="readOnly" />
                    </div>
                    <div class="item-left-two" style="padding-bottom: 0px;">
                        <BaseInput typeInput="input" label="Số phiếu chi" v-model.lazy="caPayment.CaPaymentNo" :readOnly="readOnly" />
                    </div>
                </div>
            </div>
            <div class="popup-content-right">
                <div style="text-align:right;">Tổng tiền</div>
                <div class="popup-sum-money">{{temTotalMoney}}</div>
            </div>
        </div>
        <div class="content-detail-group">
            <div class="tab-detail-group">
                <div class="tab-label">Hạch toán</div>
                <div class="tab-content">
                    <div style="padding-right: 10px;">Loại tiền</div>
                    <BaseComboboxNormal v-model="titleMoneyDefault" :datas="[]" styleComboboxNormal="width:100px;" :readOnly="readOnly" />
                </div>
            </div>
            <div class="content-detail">
                <BaseTableInsert :isColumNumber="true" :hasFooterTable="true" styleTable=" overflow-y: none;"
                    v-model="listCAPaymentDetail"
                    :complexTable="true"

                    :listFields="listFieldCAPaymentDetail"
                    :readOnly="readOnly" 

                    @changeSelectItem="changeItemListCaPaymentDetail"
                    @changeInput="changeAfterInputListCaPaymentDetail"
                    @deleteItemRow="deleteItemCaPaymentDetail"
                    @addItemRow ="addItemCaPaymentDetail"
                    @btnRemoveAll="btnRemoveAllCaPaymentDetail"
                 />
                <div class="content-file">
                    <div class="content-file-title">
                        <BaseButtonIcon iconClass="btn-attach-file"/>
                        <div class="title-file">Đính kèm</div>
                        <div>Dung lượng tối đa 5MB</div>
                    </div>
                   
                    <div class="file-payment-detail">Kéo/thả tệp vào đây hoặc bấm vào đây</div>
                </div>
            </div>
        </div>
    </div>
    <div class="popup-footer">
        <BaseButton label="Hủy" styleButton="color:white!important" @btnClick="btnCloseForm"/>
        <div class="group-button-footer" >
            <BaseButton label="Cất và Đóng" styleButton="color:white!important; margin-right:10px;" :readOnly="readOnly" @btnClick="btnSave(1)"/>
            <BaseButton label="Cất và Thêm" styleButton="color:white!important" :hasBackground="true" :readOnly="readOnly" @btnClick="btnSave(2)"/>
        </div>
    </div>
<BaseMess  v-if="isShowMessQuestion"
    typeMessage="question" 
    :titleForm="titleMessQuestion"
    @btnCancel="isShowMessQuestion = false"
    @btnYes="btnYesQuestion" 
    @btnNo="btnCloseForm"
/>
</div>
</template>

<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'
import BaseButton from '@/components/base/BaseButton.vue'
import BaseMess from '@/components/base/BaseMessage.vue'

import BaseTableInsert from '@/components/base/BaseTableInsert.vue'
import * as mylib from '../../js/resourcs.js'
import MyFunction from '@/js/function.js'
import axios from 'axios'
export default {
    components: {
        BaseButtonIcon,
        BaseButton,
        BaseComboboxNormal,
        BaseInput,
        BaseTableInsert,
        BaseMess
    },
    props:{
        editMode:{
            required: true,
            type:Number
        },
        idCaPayment:{//Biến id xem
            type:String
        }
    },
    computed:{
        temTotalMoney(){
            let temp = 0;
            for(let i = 0 ; i <this.listCAPaymentDetail.length; i++){
                temp += Number(this.listCAPaymentDetail[i].Amount);
            }
            return MyFunction.formatNumber(temp);
        },
        
    },
    watch:{
        
    },
    data() {
        return {
            titlePopupDefault: "7. Chi khác",
            titleMoneyDefault: "VND",
            isShowDetail:false,//Load xong dữ liệu thì mới mở html

            listEmployee:[],//Dùng để lưu trữ listEmployee
            listAccountObject:[],//Dùng để lưu trữ listAccountObject
            readOnly:false,//Trạng thái ban đầu của chỉ xem hay là gì

            caPayment:{}, //Dùng để lưu trữ caPayment
              
            listCAPaymentDetail:new Array(),//Dùng để lưu trữ listCaPaymentDetail,
            listFieldCAPaymentDetail: [],//Lưu trữ list detail

            lisFieldAccountObject:mylib.data.listFieldAccountObjectComboboxInsert,
            listFieldEmployee: mylib.data.listFieldEmployeeCaPayment,
            
            isShowMessQuestion:false,//Trạng thái đóng mở của form question
            titleMessQuestion:mylib.resourcs["VI"].confirmEdit,
        }
    },
    async created(){
        var me = this;
        switch (me.editMode) {
            case  mylib.misaEnum.editMode.View:
                me.readOnly = true;
                await me.getDataDetailCaPayment();
                break;
            case mylib.misaEnum.editMode.Add:
                me.$parent.isShowLoading = true;//Thực hiện loading
                await me.resetFormDetail();//Thực hiện thêm mới
               
                break;
            case mylib.misaEnum.editMode.Duplicate:
                await me.getDataDetailCaPayment();
                await me.getCaPaymentNoNew();
                break;
            default:
                break;
        }
       
    },
    async mounted(){
        var me = this;
        me.$parent.isShowLoading = true;
        await me.getListEmployee();
        await me.getListAccountObject();

        me.listFieldCAPaymentDetail =[
            {
                name: "DecriptionDetail",
                text: "DIỄN GIẢI",
                width: "350",
            },
            {
                name: "DebitAccountId",
                text: "TK NỢ",
                title: "Tài khoản nợ",
                width: "150",
                typeInsert:'combobox',
                listField:mylib.data.listFieldDebitAccountComboboxInsert,
                listData:mylib.dataSource.listDataDebitAccount,
                styleCombobox:"width: 370px;",
                keySearch:"DebitAccountId",
                propertyCompare:"DebitAccountId"
            },
            {
                name: "CreditAccountId",
                text: "TK CÓ",
                title: "Tài khoản có",
                width: "70",
                typeInsert:'combobox',
                listField:mylib.data.listFieldCreditAccountComboboxInsert,
                styleCombobox:"width: 380px;",
                listData:mylib.dataSource.listDataCreditAccount,
                keySearch:"CreditAccountId",
                propertyCompare:"CreditAccountId"
            },
            {
                name: "Amount",
                text: "SỐ TIỀN",
                width: "150",
                type:"number"
            },
            {
                name: "AccountObjectCode",
                text: "ĐỐI TƯỢNG",
                width: "100",
                listField:mylib.data.listFieldAccountObjectComboboxInsert,
                typeInsert:'combobox',
                styleCombobox:"width: 880px; right: 0",
                listData:me.listAccountObject,
                keySearch:"AccountObjectId",
                propertyCompare:"AccountObjectId"
                
            },
            {
                name: "AccountObjectName",
                text: "TÊN ĐỐI TƯỢNG",
                width: "200",
                typeInsert:'none',
            },
        ]
        me.$parent.isShowLoading = false;
        me.isShowDetail = true;
        if(me.editMode != mylib.misaEnum.editMode.View){//CÁI NÀY CẦN ĐI HỎI CÁC ANH
            console.log(" đó là ", me.$refs)//Tập trung vào ô mã đầu tiên
            console.log("đó là 2", me.$refs.AccountObject);
        } 
    },
    methods: {
        btnRemoveAllCaPaymentDetail(){
            this.listCAPaymentDetail = [];
            let objectNew = this.objectCaPaymentDetailNew();
            this.listCAPaymentDetail.push(objectNew);

        },
        addItemCaPaymentDetail(){
            let objectNew = {};
            if(this.listCAPaymentDetail.length > 0 ){//Nếu nó có đối tượng thì sẽ dữ liệu sẽ bằng đối tượng cuối cùng
                objectNew= MyFunction.sameObject(this.listCAPaymentDetail[this.listCAPaymentDetail.length - 1]);
            }
            else{//Nếu mà không có đối tượng nào hết
                objectNew = this.objectCaPaymentDetailNew();
            }
            this.listCAPaymentDetail.push(objectNew);        
        },
        /**
         * Thực hiện khi click vào nút xóa của từng dòng trong bảng detail
         * CreatedBy: HoaiPT(11/03/2022)
         */
        deleteItemCaPaymentDetail(index){
             this.listCAPaymentDetail.splice(index,1);
        },
        /**
         * Thực hiện khi thay đổi ô input đối tượng của TableInset thì gán cho Id bằng null
         * CreatedBy: HoaiPT(11/03/2022)
         */
        changeAfterInputListCaPaymentDetail({fieldName,index}){
            if(fieldName =="AccountObjectId"){
                this.listCAPaymentDetail[index].AccountObjectId = null;
                this.listCAPaymentDetail[index].AccountObjectName = ''
            }
        },
        /**
         * Thực hiện khi thay đổi của id khi lựa chọn vào dòng tương ứng khi thay đổi AccountObject vì có lưu trữ Id
         * CreatedBy: HoaiPT(11/03/2022)
         */
        changeItemListCaPaymentDetail({object,fieldName,index}){
            if(fieldName =="AccountObjectId"){
                this.listCAPaymentDetail[index].AccountObjectId = object.AccountObjectId;
                this.listCAPaymentDetail[index].AccountObjectName = object.AccountObjectName;
            }
        },
        async btnSave(value){
            try {
                var me = this;
                let objectControl ={};
                objectControl.CaPayment  = me.caPayment;
                objectControl.ListCaPaymentDetail = me.listCAPaymentDetail;
                await axios.post('https://localhost:44338/api/v1/ControlCaPayment', objectControl)
                .then(function (res) {
                    if(!res.data.errorCode){ //Không có lỗi thì sẽ vào đây
                        me.checkActionSave(value);
                    }else{//Có lỗi thì sẽ vào đây
                        me.openWarning(res);
                    }  
                })
            } catch (error) {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
           
        },
        /**
         * Kiểm tra xem thuộc trường hợp là cất và thêm hay là cất và đóng để cho phù hợp
         * CreatedBy: HoaiPT(11/03/2022)
         */
        async checkActionSave(value){
            var me = this;
            switch (value) {
                case 1://Thực hiện cất và đóng
                    me.$parent.isShowDetailCaPayment = false;//Thực hiện đóng form
                    me.$parent.showData();//Load lại dữ liệu
                    break;
                case 2://Thực hiện cất và thêm mới
                    await me.$parent.showData();//Load lại dữ liệu ở listTable
                    me.$parent.isShowLoading = true;
                    await me.resetFormDetail();
                    me.$parent.isShowLoading = false;
                    break;
                default:
                    break;
            }
        },
         /**
         * Thực hiện khi click dấu đóng
         * CreatedBy: HoaiPT(11/03/2022)
         */
        btnCloseToolTip(){
            if(this.editMode == mylib.misaEnum.editMode.View){
                this.$parent.isShowDetailCaPayment = false;
            }else{
                this.isShowMessQuestion = true;//Thực hiện mở form mess hỏi xem có muốn cất không
            }
        },
        /**
         * Thực hiện hành động khi click vào nút có của form hỏi bạn có muốn đóng không
         * CreatedBy: HoaiPT(13/03/2022)
         */
        btnYesQuestion(){
            var me =this;
            me.isShowMessQuestion = false;//Đóng form question

            me.btnSave(1);//Thực hiện hành động Cất 
        },
         /**
         * Thực hiện khi click nút hủy
         * CreatedBy: HoaiPT(11/03/2022)
         */
        btnCloseForm(){
            this.$parent.isShowDetailCaPayment = false;
        },
        /**
         * Thực hiện làm mới form detail
         */
        async resetFormDetail(){
            var me = this;
    
            me.caPayment = {};
            me.caPayment.CaPaymentNo = '';//Không biết sao cái này bị bind delay
            me.caPayment.Resion = "Chi tiền cho";
            me.caPayment.PostedDate = new Date();
            me.caPayment.CaPaymentDate = new Date();
            await me.getCaPaymentNoNew(); 

            me.listCAPaymentDetail =[];//Làm rỗng mới
            let caPaymentDetailNew = me.objectCaPaymentDetailNew();
            me.listCAPaymentDetail.push(caPaymentDetailNew);

        },
        /**
         * Thực hiện thêm Object mới (đầu tiên cho CaPaymentDetail)
         * CreatedBy: HoaiPT(11/03/2022)
         */
        objectCaPaymentDetailNew(){
            let caPaymentDetailNew ={};
            caPaymentDetailNew.Amount = 0;
            caPaymentDetailNew.CreditAccountId = "11111";
            caPaymentDetailNew.DecriptionDetail = "Chi tiền cho";
            return caPaymentDetailNew;
        },
           

        /**
         * Thực hiện lấy dữ liệu khi xem
         * CreatedBy: HoaiPT(11/03/2022)
         */
        async getDataDetailCaPayment() {
            try {
                var me = this;
                me.$parent.isShowLoading = true; //Thực hiện mở Loading
                await axios.get(`https://localhost:44338/api/v1/ControlCaPayment/${me.idCaPayment}`)
                    .then(function (res) {
                        console.log(res);
                        me.caPayment = res.data.Master;
                        me.listCAPaymentDetail = res.data.ListDetail;
                    })
                    .catch(function (res) {
                        console.log(res);
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện lấy mã CaPaymentNo max
         * CreatedBy: HoaiPT(11/03/2022)
         */
         async getCaPaymentNoNew() {
            try {
                var me = this;
                await axios.get(`https://localhost:44338/api/v1/CaPayments/CodeNew`)
                    .then(function (res) {
                        // console.log(res);
                        me.caPayment.CaPaymentNo = res.data;
                        console.log( me.caPayment.CaPaymentNo);
                    })
                    .catch(function (res) {
                        console.log(res);
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện lấy toàn bộ nhân viên
         * CreatedBy: HoaiPT(11/03/2022)
         */
        async getListEmployee() {
            try {
                var me = this;
                await axios.get('https://localhost:44338/api/v1/Employees')
                    .then(function(res) {
                        me.listEmployee = res.data;
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện lấy toàn bộ nhân viên
         * CreatedBy: HoaiPT(11/03/2022)
         */
        async getListAccountObject() {
            try {
                var me = this;
                await axios.get('https://localhost:44338/api/v1/AccountObjects')
                    .then(function(res) {
                        me.listAccountObject = res.data;
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
    },
}
</script>

<style scoped>
@import url(../../style/view/cash/ca-payment-detail.css);
</style>
