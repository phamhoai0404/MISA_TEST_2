<template>
<div class="dialog">
    <div class="dialog-content">
        <div class="dialog-header">
            <div class="dialog-title">
                <div class="title">Thông tin nhà cung cấp</div>
                <div class="group-function">
                    <div class="group-radio">
                        <BaseRadio label="Tổ chức" styleRadio="margin-right:20px;" id="organization" name="typeRadioDetail" valueReal="1" @change="changeTypeDetail" :value="typeDetail" />
                        <BaseRadio label="Cá nhân" id="personal" name="typeRadioDetail" valueReal="2" @change="changeTypeDetail" :value="typeDetail" />
                    </div>
                    <BaseCheckbox label="Là khách hàng" id="customer" styleCheckbox="margin-left:100px;" />

                </div>
            </div>

            <div class="dialog-close">

                <BaseButtonIcon iconClass="btn-icon-help" title="Giúp(F1)" />
                <BaseButtonIcon iconClass="btn-icon-close" @btnClick="btnCloseToolTip" title="Đóng(ESC)" shortKey="['esc']"  />
            </div>
        </div>

        <div class="dialog-body">
            <div class="dialog-main" id="dialog-main">
                <div class="dialog-main-one">
                    <div class="dialog-one-left">
                        <div class="dialog-two-row">
                            <div class="left-row">
                                <BaseInput typeInput="input" label="Mã số thuế" />
                            </div>

                            <div class="right-row">
                                <BaseInput typeInput="input" label="Mã nhà cung cấp" :isRequire="true" v-model="account.AccountObjectCode" :readOnly="readOnly" />
                            </div>
                        </div>
                        <div class="dialog-one-row">
                            <BaseInput typeInput="input" label="Tên nhà cung cấp" :isRequire="true" v-model="account.AccountObjectName" />
                        </div>
                        <div class="dialog-one-row">
                            <BaseInput typeInput="textarea" placeholder="VD: Số 82 Duy Tân, Dịch Vọng Hậu, Cầu Giấy, Hà Nội" label="Địa chỉ" v-model="account.Address"/>
                        </div>
                    </div>
                    <div class="dialog-one-right">
                        <div class="dialog-two-row">
                            <div class="left-row">
                                <BaseInput typeInput="input" label="Điện thoại" v-model="account.Phone"/>
                            </div>

                            <div class="right-row">
                                <BaseInput typeInput="input" label="Website" v-model="account.Website"/>
                            </div>
                        </div>
                        <div class="dialog-one-row">
                            <BaseInput typeInput="input" label="Nhóm nhà cung cấp" />
                        </div>
                        <div class="dialog-one-row">
                             <BaseComboboxNormal label="Nhân viên mua hàng"
                                v-model="account.FullName"
                                :isComboboxTable="true"
                                :isButtonAdd="true"
                                :isShowDataDropdown="isShowComboboxEmployee"
                                :listData="listEmployeeTemp"
                                :listFields="listFieldEmployee"
                                :propertyCompare="account.EmployeeId"
                                keySearch="EmployeeId"
                                @hideDataDropDown="isShowComboboxEmployee = false"
                                @btnClickDropdown="btnClickDropdownEmployee"
                                @btnClickItemTable="btnSelectItemEmployee"
                                @input="changeInputComboboxEmployee"
                            />
                        </div>
                    </div>
                </div>
                <div class="dialog-main-two">
                    <div class="tab-index-group">
                        <div v-for="(tabIndex,index) in listTabIndex" :key="index" class="tab-item" @click='selectedTabIndex(index)' :class="{'tab-item-active': tabSelected == index }">{{tabIndex}}</div>
                    </div>
                    <div class="content-tab-index">
                        <span v-if="tabSelected == 0">
                            <div class="tab-left">
                                <div class="tab-two-row">
                                    <div class="tab-two-left" style="width:30%">
                                        <BaseComboboxNormal v-model="account.Prefix"
                                            label="Người liên hệ" placeholder="Xưng hô"
                                            :isShowDataDropdown="isShowComboboxPrefix"
                                            :listData="listDataPrefixTemp"
                                            @hideDataDropDown="isShowComboboxPrefix = false"
                                            @btnClickDropdown="btnClickDropdownPrefix"
                                            @btnClickItem="btnSelectItemPrefix" 
                                            :readOnly="readOnly"
                                        />
                                    </div>
                                    <div class="tab-two-right" style="width:68%">
                                        <BaseInput typeInput="input" placeholder="Họ và tên" v-model="account.EinvoiceContactName"/>
                                    </div>

                                </div>
                                <div class="tab-one-row">
                                    <BaseInput typeInput="input" placeholder="Email" v-model="account.EinvoiceContactEmail"/>
                                </div>
                                <div class="tab-one-row">
                                    <BaseInput typeInput="input" placeholder="Số điện thoại" styleInput="width:40%;" v-model="account.EinvoiceContactMobile"/>
                                </div>

                            </div>
                            <div class="tab-right">
                                <BaseInput typeInput="input" label="Đại diện theo PL" placeholder="Đại diện theo PL" title="Đại diện theo pháp luật" v-model="account.LegalRepresentative"/>
                            </div>
                        </span>
                        <span v-if="tabSelected == 1">
                            <div>
                                <div class="tab-only-one">
                                     <BaseComboboxNormal label="Điều khoản thanh toán" styleComboboxNormal="width:204px; margin-right:10px" styleDataCombobox="width:460px;"
                                        v-model="account.PaymentTermName"
                                        :isComboboxTable="true"
                                        :isButtonAdd="true"
                                        :isShowDataDropdown="isShowComboboxPaymentTerm"
                                        :listData="listPaymentTermTemp"
                                        :listFields="listFieldPaymentTerm"
                                        :propertyCompare="account.PaymentTermId"
                                        keySearch="PaymentTermId"
                                        @hideDataDropDown="isShowComboboxPaymentTerm = false"
                                        @btnClickDropdown="btnClickDropdownPaymentTerm"
                                        @btnClickItemTable="btnSelectItemPaymentTerm"
                                        @input="changeInputComboboxPaymentTerm"
                                    />
                                    <BaseInput typeInput="input" label="Số ngày được nợ" :isNumber="true" styleInput="margin-right:10px;" v-model="account.DueTime"/>
                                    <BaseInput typeInput="input" label="Số nợ tối đa" :isNumber="true" v-model="account.MaximizeDebtAmount"/>
                                </div>
                                <div class="tab-only-one">
                                    <BaseComboboxNormal label="Tài khoản công nợ phải trả" styleComboboxNormal="margin-top: 10px; width:204px" styleDataCombobox="width:360px;"
                                        v-model="account.PayAccountName"
                                        :isComboboxTable="true"
                                        :isShowDataDropdown="isShowComboboxPayAccount"
                                        :listData="listPayAccountTemp"
                                        :listFields="listFieldPayAccount"
                                        :propertyCompare="account.PayAccountId"
                                        keySearch="PayAccountId"
                                        @hideDataDropDown="isShowComboboxPayAccount = false"
                                        @btnClickDropdown="btnClickDropdownPayAccount"
                                        @btnClickItemTable="btnSelectItemPayAccount"
                                        @input="changeInputComboboxPayAccount"
                                    />
                                </div>
                              
                            </div>
                        </span>
                        <span v-if="tabSelected == 2">
                            <div>
                                <h1>Chưa vẽ được đến đây</h1>
                            </div>
                        </span>
                        <span v-if="tabSelected == 3">
                            <div class="tab-left">
                                <div class="tab-two-row">
                                    <div class="tab-two-left" style="width:48%">
                                        <BaseInput typeInput="input" label="Vị trí địa lý" placeholder="Việt Nam" />
                                    </div>
                                    <div class="tab-two-right" style="width:48%">
                                        <BaseInput typeInput="input" placeholder="Tỉnh/Thành phố" />
                                    </div>
                                </div>
                                <div class="tab-two-row">
                                    <div class="tab-two-right" style="width:48%">
                                        <BaseInput typeInput="input" placeholder="Quận/Huyện" />
                                    </div>
                                    <div class="tab-two-right" style="width:48%">
                                        <BaseInput typeInput="input" placeholder="Xã/Phường" />
                                    </div>
                                </div>
                            </div>
                            <div class="tab-right">
                                <div class="tab-group-title">
                                   <div class="tab-title-child">Địa chỉ giao hàng</div>
                                    <BaseCheckbox label="Giống địa chỉ nhà cung cấp" id="address-same" styleCheckbox="padding-left:18px" />
                                </div>
                                <div class="tab-content-table">
                                  <h1>Đây là phần table cũng chưa làm được</h1>
                                </div>
                            </div>

                        </span>
                        <span v-if="tabSelected == 4">
                            <div style="width:100%">
                                <BaseInput typeInput="textarea" styleTextArea="height:215px;" v-model="account.Description"/>
                            </div>
                        </span>

                    </div>
                </div>
            </div>
            <div class="dialog-line "></div>
            <div class="dialog-footer ">
                <div class="footer-left ">
                    <BaseButton label="Hủy" @btnClick="btnCloseForm()" />
                </div>
                <div class="footer-right ">
                    <BaseButton label="Cất" title="Cất(Ctrl+S)" @btnClick="btnSave(1)" shortKey="['ctrl','s']" />
                    &nbsp;&nbsp;
                    <BaseButton label="Cất và Thêm" :hasBackground="true" title="Cất và Thêm(Ctrl+Shift+S)" @btnClick="btnSave(2)" shortKey="['ctrl','shift','s']" />
                </div>
            </div>
        </div>
    </div>
<BaseMessQuestion  v-if="isShowMessQuestion"
    typeMessage="question" 
    :titleForm="titleMessQuestion"
    @btnCancel="isShowMessQuestion = false"
    @btnYes="btnSave(1)" 
    @btnNo="btnCloseForm"
/>
</div>
</template>

<script>
import BaseButton from '@/components/base/BaseButton.vue'
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseRadio from '@/components/base/BaseRadio.vue'
import BaseCheckbox from '@/components/base/BaseCheckbox.vue'
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'
import BaseMessQuestion from '@/components/base/BaseMessage.vue'



import * as mylib from '@/js/resourcs.js'
import MyFunction from '@/js/function.js'
import axios from 'axios'

export default {
    components: {
        BaseButton,
        BaseButtonIcon,
        BaseRadio,
        BaseCheckbox,
        BaseInput,
        BaseComboboxNormal,
        BaseMessQuestion
    },
    props:{
        accountTable:null,//Lấy từ cha gửi vào cho con là Detail
        editMode:mylib.misaEnum.editMode.NoAction,//Mặc định hành động là chưa làm gì cả
    },
    data() {
        return {
            typeDetail: '1',//Mặc định chọn là Nhà tổ chức chỉ vẽ cho đẹp thôi không cần làm chức năng

            tabSelected: 0,//Lựa chọn mặc định sẽ là cái đầu tiên và sẽ là cái liên hệ
            listTabIndex: mylib.data.listTabIndex,//Danh sách list Tên của TabIndex được lưu trữ trong resource
            readOnly:false,//Thực hiện để mở khóa hay đóng lại các ô input

            isShowComboboxPrefix:false,//Mặc định ban đầu là đóng
            listDataPrefix:mylib.data.listPrefix,//Dữ liệu chính
            listDataPrefixTemp:[],//Tạm thời là rỗng
            
            account:{//Viết riêng rẽ từng cái ra dùng để theo dõi trong watch
                Prefix:null,
                
                EmployeeId:null,
                FullName:null,

                PayAccountId:null,
                PayAccountName:null,

            },

            titleMessQuestion:mylib.resourcs["VI"].confirmEdit,
            isShowMessQuestion:false,

            isShowComboboxEmployee:false,//Trạng thái đầu tiên của combobox
            listEmployee:null,
            listEmployeeTemp:null,
            listFieldEmployee:mylib.data.listFieldEmployeeCombobox,

            isShowComboboxPayAccount:false,//Trạng thái đầu tiên của combobox
            listPayAccount:null,
            listPayAccountTemp:null,
            listFieldPayAccount:mylib.data.listFieldPayAccountCombobox,

            isShowComboboxPaymentTerm:false,//Trạng thái đầu tiên của combobox
            listPaymentTerm:null,
            listPaymentTermTemp:null,
            listFieldPaymentTerm:mylib.data.listFieldPaymentTermCombobox,
            
        }
    },
    async created(){
        var me = this;

        if(me.editMode == mylib.misaEnum.editMode.View){//Nếu nó thuộc kiểu xem thì sẽ vô hiệu hóa các ô lại
            me.readOnly = true;
        }

        //Cần phải viết như này để nó không bind từ detail ảnh hưởng đến table
        me.account= await MyFunction.sameObject(me.accountTable);

        await me.getListEmployee()//Thực hiện gán dữ liệu cho listEmployee phục vụ cho combobox
        await me.getListPayAccount()//Thực hiện gán dữ liệu cho listPayAccount phục vụ cho combobox
        await me.getListPaymentTerm()//Thực hiện gán dữ liệu cho listPayAccount phục vụ cho combobox
    },
    watch:{
        /**
         * Thực hiện theo dõi Prefix
         * CreatedBy: HoaiPT(28/02/2021)
         */
        'account.Prefix'(valueNew){
            var me = this;

            //Kiểm tra nếu mà không tồn tại giá trị trong mảng, và cái giá trị valueNew nó có tồn tại hay không thì bắt đầu tìm kiếm
            if(! MyFunction.existValueInArray(me.listDataPrefix, valueNew) && valueNew){
                me.isShowComboboxPrefix = true;

                //Thực hiện lọc theo từ khóa truyền vào mới
                me.listDataPrefixTemp = MyFunction.selectFilter(me.listDataPrefix,valueNew);
            } 
        },
         /**
         * Thực hiện theo dõi FullName đồng thời thay đổi giá trị của EmployeeId
         * CreatedBy: HoaiPT(02/03/2021)
         */
        'account.FullName'( valueNew){
            var me = this;
            if(valueNew && me.listEmployee){//Nếu hai đối tượng này tồn tại
                if(!me.existValueInArrayObject(me.listEmployee,'FullName', valueNew)){
                    me.isShowComboboxEmployee = true;
                    me.listEmployeeTemp = me.selectFilterObject(me.listEmployee,'FullName', valueNew);
                } 
            }
            
        },
         /**
         * Thực hiện theo dõi PayAccountName đồng thời thay đổi giá trị của PayAccountId
         * CreatedBy: HoaiPT(02/03/2021)
         */
        'account.PayAccountName'( valueNew){
            var me = this;
            if(valueNew && me.listPayAccount){//Nếu hai đối tượng này tồn tại
                if(!me.existValueInArrayObject(me.listPayAccount,'PayAccountName', valueNew)){
                    me.isShowComboboxPayAccount = true;
                    me.listPayAccountTemp = me.selectFilterObject(me.listPayAccount,'PayAccountName', valueNew);
                } 
            }
            
        },
         /**
         * Thực hiện theo dõi PaymentTermName đồng thời thay đổi giá trị của PaymentTermId
         * CreatedBy: HoaiPT(02/03/2021)
         */
        'account.PaymentTermName'(valueNew){
            var me = this;
            if(valueNew && me.listPaymentTerm){//Nếu hai đối tượng này tồn tại
                if(!me.existValueInArrayObject(me.listPaymentTerm,'PaymentTermName', valueNew)){
                    me.isShowComboboxPaymentTerm = true;
                    me.listPaymentTermTemp = me.selectFilterObject(me.listPaymentTerm,'PaymentTermName', valueNew);
                } 
            }
            
        },
    },
    methods: {
        btnSave(value) {
            console.log("value " + value, this.account);
        },
       
        changeTypeDetail() {
            // alert("change type detail");
        },



        /**
         * Thực hiện khi thay đổi giá trị trong ô input
         * CreatedBy: HoaiPT(02/03/2021)
         */
        changeInputComboboxPaymentTerm(){
            this.account.PaymentTermId = null;
        },
         /**
         * Thực hiện click vào item bất kì trong data combobox PayAccount
         * CreatedBy: HoaiPT(02/03/2021)
         */
        btnSelectItemPaymentTerm({object}){
            this.account.PaymentTermId = object.PaymentTermId;
            this.account.PaymentTermName = object.PaymentTermName;
            this.isShowComboboxPaymentTerm = false;  
        },
        /**
         * Thực hiện click vào nút dropdown ở combobox PaymentTerm
         * CreatedBy: HoaiPT(02/03/2021)
         */
        btnClickDropdownPaymentTerm(){
            this.listPaymentTermTemp = this.listPaymentTerm;//Thực hiện gán toàn bộ dữ liệu vào tạm
            this.isShowComboboxPaymentTerm = !this.isShowComboboxPaymentTerm;
        },
         /**
         * Thực hiện khi thay đổi giá trị trong ô input
         * CreatedBy: HoaiPT(02/03/2021)
         */
        changeInputComboboxPayAccount(){
            this.account.PayAccountId = null;
        },
         /**
         * Thực hiện click vào item bất kì trong data combobox PayAccount
         * CreatedBy: HoaiPT(02/03/2021)
         */
        btnSelectItemPayAccount({object}){
            this.account.PayAccountId = object.PayAccountId;
            this.account.PayAccountName = object.PayAccountName;
            this.isShowComboboxPayAccount = false;  
        },
        /**
         * Thực hiện click vào nút dropdown ở combobox PayAccount
         * CreatedBy: HoaiPT(02/03/2021)
         */
        btnClickDropdownPayAccount(){
            this.listPayAccountTemp = this.listPayAccount;//Thực hiện gán toàn bộ dữ liệu vào tạm
            this.isShowComboboxPayAccount = !this.isShowComboboxPayAccount;
        },
        /**
         * Thực hiện khi thay đổi giá trị trong ô input
         * CreatedBy: HoaiPT(02/03/2021)
         */
        changeInputComboboxEmployee(){
            this.account.EmployeeId = null;//Gán giá trị cho mã nhân viên của nhà cung cấp bằng null
        },
         /**
         * Thực hiện click vào item bất kì trong data combobox employee
         * CreatedBy: HoaiPT(02/03/2021)
         */
        btnSelectItemEmployee({object}){
            this.account.EmployeeId = object.EmployeeId;
            this.account.FullName = object.FullName;
            this.isShowComboboxEmployee = false;  
        },
        /**
         * Thực hiện click vào nút dropdown ở combobox employee
         * CreatedBy: HoaiPT(02/03/2021)
         */
        btnClickDropdownEmployee(){
            this.listEmployeeTemp = this.listEmployee;//Thực hiện gán toàn bộ dữ liệu vào tạm
            this.isShowComboboxEmployee = !this.isShowComboboxEmployee;
        },
        /**
         * Thực hiện khi click vào nút nhân ở bên góc phải trên cùng màn hình
         * CreatedBy: HoaiPT(02/03/2021)
         */
        btnCloseToolTip(){
            var me = this;

            //So sánh đối tượng lúc bắt đầu chuyển từ ngoài vào form detail với đối tượng account hiện tại
            if(MyFunction.comparisonObject(me.accountTable,me.account)){
                me.btnCloseForm();//Nếu hai đối tượng giống nhau thì bắt đầu đóng form
            }else{
                //Còn hai đối tượng khác nhau
                me.isShowMessQuestion = true;//Thực hiện mở form question 
            }
        },
         /**
         * Thực hiện khi click vào nút hủy trong Trong form Account Detail
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnCloseForm() {
            // var me = this;

            //Thực hiện đóng form detail
            this.$parent.isShowAccountDetail = false;
        },
        /**
         * Thực hiện khi select cái TabIndex để thay đổi view xem và thêm thông tin
         * CreatedBy: HoaiPT(28/02/2021)
         */
        selectedTabIndex(index) {
            var me = this;
            me.tabSelected = index;
        },
        /**
         * Thực hiện khi click vào nút dropdown của Prefix
         * CreatedBy: HoaiPT(28/02/2021)
         */
        btnClickDropdownPrefix(){
            this.listDataPrefixTemp = this.listDataPrefix;//Gán dữ liệu tất cả vào tạm --> Lấy ra toàn bộ ấy
            this.isShowComboboxPrefix = !this.isShowComboboxPrefix;//Thực hiện chuyển đổi trạng thái
        },
        /**
         * Thực hiện khi click vào một item trong listDataPrefixTemp
         * CreatedBy: HoaiPT(28/02/2021)
         */
        btnSelectItemPrefix({object}){
            this.account.Prefix = object;//Thực hiện gán đối tượng vào cho Prefix
            this.isShowComboboxPrefix = false; //Đóng data combobox của Prefix
        },
        async getListPaymentTerm() {
            try {
                var me = this;
                await axios.get('https://localhost:44338/api/v1/PaymentTerms')
                    .then(function(res) {
                        me.listPaymentTerm = res.data;
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
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
        async getListPayAccount() {
            try {
                var me = this;
                await axios.get('https://localhost:44338/api/v1/PayAccounts')
                    .then(function(res) {
                        me.listPayAccount = res.data;
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện lấy những cái này từ file js
         * CreatedBy:HoaiPT(02/03/2022)
         */
        selectFilter:MyFunction.selectFilter,
        existValueInArray:MyFunction.existValueInArray,
        existValueInArrayObject:MyFunction.existValueInArrayObject,
        selectFilterObject:MyFunction.selectFilterObject,
        sameObject:MyFunction.sameObject,
    }
}
</script>

<style scoped>
@import url(../../style/view/account_object/account-detail.css);
</style>
