<template>
<div class="popup-detail" >
    <div class="popup-top-header">
        <div class="top-header-left">
            <BaseButtonIcon iconClass="btn-clock" />
            <div class="title-top-header-left">Phiếu chi {{caPayment.CaPaymentNo}}</div>
            <div style="padding-left:24px;">
                <BaseComboboxNormal v-model="titlePopupDefault" :datas="[]" styleComboboxNormal="width:350px;" :readOnly="readOnly"  ref="titlePopupDefault"/>
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
                                :errorCombobox="errorAccountObject"
                                :title="titleAccountObject"
                                :readOnly="readOnly"

                                :listFields="lisFieldAccountObject"
                                :datas="listAccountObject" 

                                inputText="AccountObjectName"
                                :propertyCompare="caPayment.AccountObjectId"
                                keySearch="AccountObjectId"
                                ref="AccountObject"

                                @onChangeValueKeySearch="changeIdAccountObject"
                                @input="changeInputAccountObject"
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
                                :errorCombobox="errorFullName"
                                :title="titleFullName"

                                :listFields="listFieldEmployee" 
                                :datas="listEmployee"
            
                                inputText="FullName"
                                :propertyCompare="caPayment.EmployeeId"
                                keySearch="EmployeeId"

                                @onChangeValueKeySearch="changeIdEmployee"
                                @input="changeInputFullName" 
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
                        <BaseInput typeInput="date" label="Ngày hạch toán" 
                            v-model="caPayment.PostedDate" :readOnly="readOnly"
                            :errorInput="errorPostedDate"
                            :title="titlePostedDate"
                            @inputChange="changeInputPostedDate"
                            @changInputDate="changeValuePostedDate"
                        />
                    </div>
                    <div class="item-left-two">
                        <BaseInput typeInput="date" label="Ngày phiếu chi" 
                            v-model="caPayment.CaPaymentDate" :readOnly="readOnly"
                            :errorInput="errorCaPaymentDate"
                            :title="titleCaPaymentDate"
                            @inputChange="changeInputCaPaymentDate"
                            @input="changeInputCaPaymentDate"
                        />
                    </div>
                    <div class="item-left-two" style="padding-bottom: 0px;">
                        <BaseInput typeInput="input" label="Số phiếu chi" 
                            v-model="caPayment.CaPaymentNo" 
                            :readOnly="readOnly"
                            :errorInput="errorNo"
                            :title="titleNo"

                            @input="changeInputCaPaymentNo"
                            ref="CaPaymentNo"
                        />
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

<BaseMess  v-if="isShowMessWarning"
    typeMessage="warning" 
    :titleForm="titleMessWarning"
    @btnYes="isShowMessWarning = false"
    
/>

<BaseMess  v-if="isShowMessInfo"
    typeMessage="info" 
    :titleForm="titleMessInfo"
    @btnClose="isShowMessInfo = false"  
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
        totalMoney(){
            let temp = 0;
            for(let i = 0 ; i <this.listCAPaymentDetail.length; i++){
                temp += Number(this.listCAPaymentDetail[i].Amount);
            }
            return temp;
        }
    },
    watch:{
        /**
         * Thực hiện theo dõi Resion và gán giá trị cho list nếu giống nhau
         * CreatedBy: HoaiPT(18/03/2022)
         */
        'caPayment.Resion'(valueNew, valueOld){
            if(valueOld ==""){//Nếu giá trị cũ của Resion caPayment là "" thì những giá trị của list bằng giá trị mới của Resion
                for(let i = 0 ; i< this.listCAPaymentDetail.length; i++){
                    this.listCAPaymentDetail[i].DecriptionDetail = valueNew;
                }
            }else{
                for(let i = 0 ; i< this.listCAPaymentDetail.length; i++){
                    if(valueOld == this.listCAPaymentDetail[i].DecriptionDetail){ //Nếu giá trị cũ của list mà bằng giá trị cũ của Resion thì giá trị mới nó cũng bằng của Resion
                        this.listCAPaymentDetail[i].DecriptionDetail = valueNew;
                    }
                }
                
            }
        },
        /**
         * Thực hiện theo dõi của AccountObjectId
         * CreatedBy: HoaiPT(18/03/2022)
         */
        'caPayment.AccountObjectId'(valueNew, valueOld){
            if(valueNew){
                for(let i = 0 ; i< this.listCAPaymentDetail.length; i++){
                    if(this.listCAPaymentDetail[i].AccountObjectId == null){ //Nếu mà giá trị nó bằng null của từng list thì nó sẽ bằng giá trị mới của đối tượng trên caPayment
                        this.listCAPaymentDetail[i].AccountObjectId = valueNew;
                        let tempObject = MyFunction.getObjectArray(this.listAccountObject,'AccountObjectId',valueNew);
                        this.listCAPaymentDetail[i].AccountObjectCode = tempObject.AccountObjectCode;
                        this.listCAPaymentDetail[i].AccountObjectName = tempObject.AccountObjectName;
                    }
                }
                for(let i = 0 ; i< this.listCAPaymentDetail.length; i++){
                    if(this.listCAPaymentDetail[i].AccountObjectId == valueOld){ //Nếu giá trị của trong list mà bằng giá trị cũ của AccountObject trên caPayment thì giá trị mới nó cũng bằng như caPayment
                        this.listCAPaymentDetail[i].AccountObjectId = valueNew;
                        let tempObject = MyFunction.getObjectArray(this.listAccountObject,'AccountObjectId',valueNew);
                        this.listCAPaymentDetail[i].AccountObjectCode = tempObject.AccountObjectCode;
                        this.listCAPaymentDetail[i].AccountObjectName = tempObject.AccountObjectName;
                    }
                }
               
            }
            if(valueNew == null){//Nếu giá trị mới bằng null mà giá trị cũ của nó bằng dưới cái list thì dưới cái list cũng bằng null
                for(let i = 0 ; i< this.listCAPaymentDetail.length; i++){
                    if(this.listCAPaymentDetail[i].AccountObjectId == valueOld){ //Nếu giá trị của trong list mà bằng giá trị cũ của AccountObject trên caPayment thì
                        this.listCAPaymentDetail[i].AccountObjectId = null;
                        this.listCAPaymentDetail[i].AccountObjectCode = '';
                        this.listCAPaymentDetail[i].AccountObjectName = '';
                    }
                }

            }
            
        }
    },
    data() {
        return {
            titlePopupDefault: "7. Chi khác",
            titleMoneyDefault: "VND",
            isShowDetail:false,//Load xong dữ liệu thì mới mở html

            listEmployee:[],//Dùng để lưu trữ listEmployee
            listAccountObject:[],//Dùng để lưu trữ listAccountObject
            readOnly:false,//Trạng thái ban đầu của chỉ xem hay là gì

            caPayment:{
            }, //Dùng để lưu trữ caPayment
              
            listCAPaymentDetail:new Array(),//Dùng để lưu trữ listCaPaymentDetail,
            listFieldCAPaymentDetail: [],//Lưu trữ list detail

            lisFieldAccountObject:mylib.data.listFieldAccountObjectComboboxInsert,
            listFieldEmployee: mylib.data.listFieldEmployeeCaPayment,
            
            isShowMessQuestion:false,//Trạng thái đóng mở của form question
            titleMessQuestion:mylib.resourcs["VI"].confirmEdit,

            isShowMessWarning:false,//Trạng thái của message cảnh báo
            titleMessWarning:"",
            isShowMessInfo:false,//Trạng thái của message lỗi thông tin
            titleMessInfo:"",

            errorNo:false,//Viền đỏ hay không của CaPaymentNo
            titleNo:"",//Title của input CaPaymentNo,

            titleAccountObject:"",//Title của combobox Đối tượng
            errorAccountObject:false,//Viền đỏ hay không AccountObject
            errorFullName:false,//Viền đỏ hay không của Nhân viên
            titleFullName:"",//Title của combobox Nhân viên

            errorPostedDate:false,//Viền đỏ hay không của PostedDate
            titlePostedDate:"",//Title của PostedDate
            errorCaPaymentDate:false,//Viền đỏ hay không của CaPaymentDate,
            titleCaPaymentDate:"",//title của CaPaymentDate

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
        if(me.editMode != mylib.misaEnum.editMode.View){
            me.$refs.titlePopupDefault.focus();
        } 
    },
    methods: {
        /**
         * Thực hiện khi thay đổi giá trị của PostedDate
         * CreatedBy: HoaiPT(17/03/2022)
         */
        changeValuePostedDate(valueNew, valueOld){
            this.changeInputPostedDate();//Thực hiện xóa bỏ viền đỏ nếu có
            if(valueNew !=null){
                let valueOldTemp = MyFunction.formatDate(valueOld);
                let valueCaPaymentDate = MyFunction.formatDate(this.caPayment.CaPaymentDate);
                if(valueOldTemp == valueCaPaymentDate){
                    this.caPayment.CaPaymentDate = valueNew;
                }
                
            }
        },
        /**
         * Thực hiện khi ấn phím bất kì trong ô input CaPaymentDate
         * CreatedBy: HoaiPT(17/03/2022)
         */
        changeInputCaPaymentDate(){
            this.errorCaPaymentDate = false;//Xóa viền đỏ
            this.titleCaPaymentDate ="";//Làm rỗng title
        },
        /**
         * Thực hiện khi ấn phím bất kì trong ô input PostedDate
         * CreatedBy: HoaiPT(17/03/2022)
         */
        changeInputPostedDate(){
            this.errorPostedDate = false;//Xóa viền đỏ
            this.titlePostedDate ="";//Làm rỗng title
        },
        /**
         * Thực hiện khi thay đổi giá trị Input của FullName (Tên nhân viên)
         * CreatedBy: HoaiPT(17/03/2022)
         */
        changeInputFullName(){
            this.errorFullName = false;//Xóa bỏ viền đỏ nếu có lỗi
            this.titleFullName = "";//Xóa bỏ title nếu có lỗi
            this.caPayment.EmployeeId = null;//Set Id bằng null
        },
        /**
         * Thực hiện khi thay đổi select Id của EmployeeId
         * CreatedBy: HoaiPT(17/03/2022)
         */
        changeIdEmployee(object){
            this.caPayment.EmployeeId = object.EmployeeId;
        },
        /**
         * Thực hiện khi thay đổi giá trị Input của AccountObject
         * CreatedBy: HoaiPT(17/03/2022)
         */
        changeInputAccountObject(){
            this.errorAccountObject = false;//Xóa bỏ viền đỏ nếu có lỗi
            this.titleAccountObject = "";//Xóa bỏ title nếu có lỗi
            this.caPayment.AccountObjectId = null;//Set Id bằng null
        },
        /**
         * Thực hiện khi thay đổi Id của AccountObject
         * CreatedBy: HoaiPT(17/03/2022)
         */
        changeIdAccountObject(object){
            this.caPayment.AccountObjectId = object.AccountObjectId;
        },
        /**
         * Thực hiện khi thay đổi giá trị của ô input CaPaymentNo
         * CreatedBy: HoaiPT(17/03/2022)
         */
        changeInputCaPaymentNo(valueNew){
            var me = this;
            if(valueNew !=null){
                if(valueNew.trim()==""){//Nếu mà nó để trống thì báo lỗi
                    me.errorNo = true;
                    me.titleNo = mylib.resourcs["VI"].notNullNo;
                }else{//Còn nếu mà không trống thì không báo lỗi gì cả
                    me.errorNo = false;
                    me.titleNo = "";
                }
            }  
        },
        /**
         * Thực hiện khi click vào nút Xác nhận xóa tất cả Detail
         * CreatedBy: HoaiPT(11/03/2022)
         */
        btnRemoveAllCaPaymentDetail(){
            this.listCAPaymentDetail = [];
            let objectNew = this.objectCaPaymentDetailNew();
            this.listCAPaymentDetail.push(objectNew);

        },
        /**
         * Thực hiện khi click vào nút thêm dòng ở Detail
         * CreatedBy: HoaiPT(11/03/2022)
         */
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
                if( !me.validateCaPayemntNoNotNull()){//Thực hiện validate ô CaPaymentNo không được để trống
                    return;
                }
                if( !me.validateFormatCaPaymentNo()){//Thực hiện validate đúng định dạng ô CaPaymentNo
                    return;
                }
                if( !me.validateEmployeeId()){//Thực hiện validate EmployeeId nếu mà nó có chữ chứa của input mà Id nó bằng null thì thực hiện thông báo lỗi
                    return;
                }
                if( !me.validateAccountObjectId()){//Thực hiện validate AccountObjectId nếu mà nó có chữ chứa của input mà Id nó bằng null thì thực hiện thông báo lỗi
                    return;
                }
                if( !me.validateDate()){//Thực hiện validate Ngày tháng của ngày hạch toán và ngày phiếu chi
                    return;
                }
                if(! me.validateListDetail()){//Thực hiện validate List
                    return;
                }

                this.caPayment.TotalAmount = this.totalMoney;//Lưu vào Amount tổng số tiền

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
         * Thực hiện validate Detail của CaPayment detail
         * CreatedBy: HoaiPT(18/03/2022)
         */
        validateListDetail(){
            var me = this;
            
            if(this.listCAPaymentDetail.length == 0){//list detail phải có ít nhất một dòng detail thì mới được
                me.titleMessInfo = mylib.resourcs['VI'].notNullListCaPaymentDetail;
                me.isShowMessInfo = true;
                return false;
            }
            for(let i = 0 ; i< this.listCAPaymentDetail.length; i++){
                if( this.listCAPaymentDetail[i].DebitAccountId == null || this.listCAPaymentDetail[i].DebitAccountId ==""){//Các dòng tài khoản nợ không được để trống
                    me.titleMessInfo =`TK nợ ở hàng ${i + 1} không được để trống!`,
                    me.isShowMessInfo = true;
                    return false;
                }
                if(this.listCAPaymentDetail[i].CreditAccountId == null || this.listCAPaymentDetail[i].CreditAccountId ==""){//Các dòng tài khoản có không được để trống
                    me.titleMessInfo =`TK có ở hàng ${i + 1} không được để trống!`,
                    me.isShowMessInfo = true;
                    return false;
                }

                //Kiểm tra xem có tồn tại mã TK nợ trong hệ thống hay không nếu không thì thông báo lỗi
                if(!MyFunction.valueInArray(mylib.dataSource.listDataDebitAccount, 'DebitAccountId', this.listCAPaymentDetail[i].DebitAccountId)){
                    me.titleMessInfo =`TK nợ ở hàng ${i + 1} không tồn tại trong hệ thống!`,
                    me.isShowMessInfo = true;
                    return false;
                }

                //Kiểm tra xem có tồn tại mã TK cótrong hệ thống hay không nếu không thì thông báo lỗi
                if(!MyFunction.valueInArray(mylib.dataSource.listDataCreditAccount, 'CreditAccountId', this.listCAPaymentDetail[i].CreditAccountId)){
                    me.titleMessInfo =`TK có ở hàng ${i + 1} không tồn tại trong hệ thống!`,
                    me.isShowMessInfo = true;
                    return false;
                }

                if( this.listCAPaymentDetail[i].AccountObjectId == null && this.listCAPaymentDetail[i].AccountObjectCode !=null){
                    if(this.listCAPaymentDetail[i].AccountObjectCode.trim() != ""){
                        me.titleMessInfo =`Hàng ${i + 1} có mã đối tượng không tồn tại trên hệ thống!`,
                        me.isShowMessInfo = true;
                        return false;
                    }
                }
            }



            return true;
        },
        /**
         *Thực hiện validate của ngày hạch toán và ngày phiếu chi
         * CreatedBy: HoaiPT(17/03/2022)
         */
        validateDate(){
            var me = this;
            //Validate ngày Ngày phiếu chi và ngày hạch toán không được để trống
            if(me.caPayment.PostedDate == null || me.caPayment.CaPaymentDate == null){//
                me.titleMessInfo ="";
                if(me.caPayment.PostedDate == null){//
                    me.titlePostedDate = mylib.resourcs["VI"].notNullPostedDate;
                    me.errorPostedDate = true;

                    me.titleMessInfo += "Ngày hạch toán";

                }
                if(me.caPayment.CaPaymentDate == null){
                    me.titleCaPaymentDate = mylib.resourcs["VI"].notNullCaPaymentDate;
                    me.errorCaPaymentDate = true;

                    me.titleMessInfo += me.titleMessInfo ==""?"Ngày phiếu chi": ", Ngày phiếu chi ";
                    
                }

                me.titleMessInfo +=" không được để trống";
                me.isShowMessInfo = true;
                return false;
            }

            //Ngày hạch toán phải lớn hơn ngày phiếu chi
            let tempPostedDate = new Date(me.caPayment.PostedDate);
            let tempCaPaymentDate = new Date(me.caPayment.CaPaymentDate);
            if(tempPostedDate < tempCaPaymentDate){
                me.titlePostedDate = mylib.resourcs['VI'].errorPostedDateLessCaPaymentDate;
                me.errorPostedDate = true;//Xuất hiện viền đỏ của ngày hạch toán

                me.titleMessInfo = mylib.resourcs['VI'].errorPostedDateLessCaPaymentDate;
                me.isShowMessInfo = true;
                return false;
            }

            return true;//Thực hiện thông qua
        },
        /**
         * Validate nhân viên là AccountObjectId có chứa Id hay không 
         * Nếu mà không chứa Id mà ô input có giá trị thì thực hiện thông báo lỗi
         * CreatedBy: HoaiPT(17/03/2022)
         */
        validateAccountObjectId(){
             var me = this;
            if(me.caPayment.AccountObjectId == null && me.caPayment.AccountObjectName != null){//Nếu mà không tồn tại mã    
                if(me.caPayment.AccountObjectName.trim() !=""){//Nếu mà AccountObjectName bằng rỗng thì cũng cho qua
                    me.errorAccountObject = true;
                    me.titleAccountObject = mylib.resourcs["VI"].notExistAccountObjectId;

                    me.titleMessInfo = mylib.resourcs["VI"].notExistAccountObjectId;
                    me.isShowMessInfo = true;
                    return false;//Nếu mà tồn tại giá trị thì không cho qua
                } 
            }
            return true;//Cho qua
        },
        /**
         * Validate nhân viên là EmployeeId có chứa Id hay không 
         * Nếu mà không chứa Id mà ô input có giá trị thì thực hiện thông báo lỗi
         * CreatedBy: HoaiPT(17/03/2022)
         */
        validateEmployeeId(){
            var me = this;
            if(me.caPayment.EmployeeId == null && me.caPayment.FullName != null){//Nếu mà không tồn tại mã    
                if(me.caPayment.FullName.trim() != ""){//Nếu mà FullName bằng rỗng thì cũng cho qua
                    me.errorFullName = true;
                    me.titleFullName = mylib.resourcs["VI"].notExistEmployeeId;

                    me.titleMessInfo = mylib.resourcs["VI"].notExistEmployeeId;
                    me.isShowMessInfo = true;
                    return false;//Nếu mà tồn tại giá trị thì không cho qua
                } 
            }
            return true;//Cho qua
        },
        /**
         * Kiểm tra xem trường dữ liệu CaPayemntNo phải đúng định dạng
         * CreatedBy: HoaiPT(11/03/2022)
         */
        validateFormatCaPaymentNo(){
            var me = this;
            let temp = /^PC[0-9]{5}$/.test(me.caPayment.CaPaymentNo);
            if (temp == true)return true;
            else{
                me.errorNo = true;//Thể hiện viền đỏ của CaPaymentNo
                me.titleNo = mylib.resourcs["VI"].errorFormatCaPaymentNo;

                me.titleMessInfo = mylib.resourcs["VI"].errorFormatCaPaymentNo;
                me.isShowMessInfo = true;//Hiện Message thông báo lỗi 

                return false;
            } 
        },
         /**
         * Kiểm tra xem trường dữ liệu CaPayemntNo không được để trống
         * CreatedBy: HoaiPT(11/03/2022)
         */
        validateCaPayemntNoNotNull(){
            if(this.caPayment.CaPaymentNo.trim() ==""){//nếu nó khác rỗng
                this.errorNo = true;//Hiện viền đỏ
                this.titleNo = mylib.resourcs["VI"].notNullNo;

                this.titleMessInfo = mylib.resourcs["VI"].notNullNo;
                this.isShowMessInfo = true;//Hiển thị form Info lỗi số phiếu chi không được phép để trống
                return false;
            } 
            return true;//có giá trị thì đúng ấy => thì cho qua
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
         * Thực hiện kiểm tra xem mã lỗi là gì để trả về lỗi tương ứng
         * CreadBy: HoaiPT(17/03/2022)
         */
        openWarning(res){
            var me = this;
            let tempTitleMessWarning ='';
            switch (res.data.errorCode) {
                case mylib.misaEnum.errorCode.Duplicate:
                    me.errorNo = true;
                    me.titleNo = `Số phiếu chi <${me.caPayment.CaPaymentNo}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.`;
                    tempTitleMessWarning = `Số phiếu chi <${me.caPayment.CaPaymentNo}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.`;
                    break;
                case mylib.misaEnum.errorCode.NotFormat:
                    me.errorNo = true;
                    me.titleNo = `Số phiếu chi <${me.caPayment.CaPaymentNo}> không đúng định dạng, vui lòng kiểm tra lại.`;
                    tempTitleMessWarning = `Số phiếu chi <${me.caPayment.CaPaymentNo}> không đúng định dạng, vui lòng kiểm tra lại.`;
                    break;
                case mylib.misaEnum.errorCode.Empty:
                    tempTitleMessWarning ='Trường dữ liệu không được để trống!';
                    break;
                default:
                    tempTitleMessWarning ="Đã có lỗi xảy ra!";
                    break;
            }
            me.titleMessWarning = tempTitleMessWarning;
            me.isShowMessWarning = true;
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
    
            me.caPayment  = {//Phải viết rõ ra như này thì nó mới ăn binding  nếu không nó binding rất chậm
                CaPaymentNo: null,
                CaPaymentDate:null,
                PostedDate:null,
                Resion:null,
                AccountObjectId:null,
                AccountObjectName:null
            };
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
            let caPaymentDetailNew ={
                AccountObjectId:null,
                AccountObjectCode:null,
                AccountObjectName:null,
            };
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
                        me.caPayment.CaPaymentNo = res.data;
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
         * Thực hiện lấy toàn bộ nhà cung cấp
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
