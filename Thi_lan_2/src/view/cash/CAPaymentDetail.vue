<template>
<div class="popup-detail" >
    <div class="popup-top-header">
        <div class="top-header-left">
            <BaseButtonIcon iconClass="btn-clock" />
            <div class="title-top-header-left">Phiếu chi {{caPayment.CaPaymentNo}}</div>
            <div style="padding-left:24px;">
                <BaseComboboxNormal v-model="titlePopupDefault" :datas="[]" styleComboboxNormal="width:350px;" />
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
                <BaseButtonIcon iconClass="btn-icon-close" />
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
                            />
                        </div>
                        <div style="width:59%;">
                            <BaseInput typeInput="input" label="Người nhận"  v-model="caPayment.Receiver" />
                        </div>
                    </div>
                    <div class="left-row">
                        <BaseInput typeInput="input" label="Địa chỉ" v-model="caPayment.Address" />
                    </div>
                    <div class="left-row">
                        <BaseInput typeInput="input" label="Lý do"  v-model="caPayment.Resion" />
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
                            <BaseInput typeInput="input" label="Kèm theo" :isNumber="true" placeholder="Số lượng" styleInput="width: 40%;"  v-model="caPayment.AttachNumber"/>
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
                        <BaseInput typeInput="date" label="Ngày hạch toán" v-model="caPayment.PostedDate" />
                    </div>
                    <div class="item-left-two">
                        <BaseInput typeInput="date" label="Ngày phiếu chi" v-model="caPayment.CaPaymentDate" />
                    </div>
                    <div class="item-left-two" style="padding-bottom: 0px;">
                        <BaseInput typeInput="input" label="Số phiếu chi" v-model="caPayment.CaPaymentNo" />
                    </div>
                </div>
            </div>
            <div class="popup-content-right">
                <div style="text-align:right;">Tổng tiền</div>
                <div class="popup-sum-money">0000</div>
            </div>
        </div>
        <div class="content-detail-group">
            <div class="tab-detail-group">
                <div class="tab-label">Hạch toán</div>
                <div class="tab-content">
                    <div style="padding-right: 10px;">Loại tiền</div>
                    <BaseComboboxNormal v-model="titleMoneyDefault" :datas="[]" styleComboboxNormal="width:100px;" />
                </div>
            </div>
            <div class="content-detail">
                <BaseTableInsert :isColumNumber="true" :hasFooterTable="true" styleTable=" overflow-y: none;"
                    v-model="listCAPaymentDetail"
                    :listFields="listFieldCAPaymentDetail"

                    @changeSelectItem="changeItemListCaPaymentDetail"
                    @changeInput="changeAfterInputListCaPaymentDetail"    
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
        <BaseButton label="Hủy" styleButton="color:white!important"/>
        <div class="group-button-footer" >
            <BaseButton label="Cất và Đóng" styleButton="color:white!important; margin-right:10px;"/>
            <BaseButton label="Cất và Thêm" styleButton="color:white!important" :hasBackground="true"/>
        </div>
    </div>

</div>
</template>

<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'
import BaseButton from '@/components/base/BaseButton.vue'

import BaseTableInsert from '@/components/base/BaseTableInsert.vue'
import * as mylib from '../../js/resourcs.js'
import axios from 'axios'
export default {
    components: {
        BaseButtonIcon,
        BaseButton,
        BaseComboboxNormal,
        BaseInput,
        BaseTableInsert
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
    data() {
        return {
            titlePopupDefault: "7. Chi khác",
            titleMoneyDefault: "VND",
            isShowDetail:false,//Load xong dữ liệu thì mới mở html

            listEmployee:[],//Dùng để lưu trữ listEmployee
            listAccountObject:[],//Dùng để lưu trữ listAccountObject
            readOnly:false,//Trạng thái ban đầu của chỉ xem hay là gì

            caPayment:{},//Dùng để lưu trữ caPayment
            listCaPaymentDetail:[],//Dùng để lưu trữ listCaPaymentDetail

            lisFieldAccountObject:mylib.data.listFieldAccountObjectComboboxInsert,
            listFieldEmployee: mylib.data.listFieldEmployeeCaPayment,

            listFieldCAPaymentDetail: [
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
                    listData:mylib.dataTest.listAccount,
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

        }
    },
    created(){
        var me = this;
        me.getDataDetailCaPayment();
    },
    async mounted(){
        var me = this;
        me.$parent.isShowLoading = true;
        await me.getListEmployee();
        await me.getListAccountObject();
        me.$parent.isShowLoading = false;
        me.isShowDetail = true;
        
    },
    methods: {
        changeAfterInputListCaPaymentDetail({fieldName,index}){
            // console.log("đó là", fieldName,index );
            if(fieldName =="AccountObjectId"){
                this.listCAPaymentDetail[index].AccountObjectId = null;
            }
        },
        changeItemListCaPaymentDetail({object,fieldName,index}){
            // console.log("đó là 2: ", idNew, fieldName, index);
            if(fieldName =="AccountObjectId"){
                this.listCAPaymentDetail[index].AccountObjectId = object.AccountObjectId;
                this.listCAPaymentDetail[index].AccountObjectName = object.AccountObjectName;
            }
        },
        async getDataDetailCaPayment() {
            try {
                var me = this;
                me.$parent.isShowLoading = true; //Thực hiện mở Loading
                await axios.get(`https://localhost:44338/api/v1/ControlCaPayment/${me.idCaPayment}`)
                    .then(function (res) {
                        console.log(res);
                        me.caPayment = res.data.Master;
                        me.listCAPaymentDetail = res.data.ListDetail;
                        me.$parent.isShowLoading = false;//Đóng loading
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
