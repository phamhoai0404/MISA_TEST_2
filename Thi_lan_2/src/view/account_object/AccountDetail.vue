<template v-if="isLoadDataTrue">
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
                                <BaseInput typeInput="input" label="Mã số thuế"
                                    v-model="account.TaxCode"
                                    :readOnly="readOnly" 
                                    ref="TaxCode" 
                                 />
                            </div>
                            <div class="right-row">
                                <BaseInput typeInput="input" label="Mã nhà cung cấp" :isRequire="true"
                                    v-model="account.AccountObjectCode" 
                                    :readOnly="readOnly"
                                    :errorInput="errorCode"
                                    :title="titleCode"
                                 />
                            </div>
                        </div>
                        <div class="dialog-one-row">
                            <BaseInput typeInput="input" label="Tên nhà cung cấp" :isRequire="true" 
                                v-model="account.AccountObjectName"
                                :readOnly="readOnly"
                                :errorInput="errorName"
                                :title="titleName" 
                            />
                        </div>
                        <div class="dialog-one-row">
                            <BaseInput typeInput="textarea" placeholder="VD: Số 82 Duy Tân, Dịch Vọng Hậu, Cầu Giấy, Hà Nội" label="Địa chỉ" 
                                v-model="account.Address"
                                :readOnly="readOnly"
                            />
                        </div>
                    </div>
                    <div class="dialog-one-right">
                        <div class="dialog-two-row">
                            <div class="left-row">
                                <BaseInput typeInput="input" label="Điện thoại" 
                                v-model="account.Phone"
                                :readOnly="readOnly"
                                />
                            </div>
                            <div class="right-row">
                                <BaseInput typeInput="input" label="Website" 
                                    v-model="account.Website"
                                    :readOnly="readOnly"
                                />
                            </div>
                        </div>
                        <div class="dialog-one-row" v-if="isShowDropDownAccountObjectGroup">
                            <BaseComboboxGroup label="Nhóm nhà cung cấp" :isButtonAdd="true"
                                v-model="textSearchAccountObjectGroup" 
                                :readOnly="readOnly"

                                :errorCombobox="errorAccountObjectGroup"
                                :title="titleAccountObjectGroup"

                                :listFields="listFieldAccountObjectGroup"
                                :datas="listAccountObjectGroup"
                                
                                :listDataSelectedSource="listAccountGroupSelected"
                                
                                keySearch="AccountObjectGroupCode" 
                                inputText="AccountObjectGroupName"
                                @updateListDataSelected="changeListAccountGroupSelected"
                                @input="changeSearchTextAccountGroup"
                            />
                        </div>
                        <div class="dialog-one-row" v-if="isShowEmployee">
                             <BaseComboboxNormal label="Nhân viên mua hàng" :isButtonAdd="true"
                                v-model="account.FullName"
                                :isComboboxTable="true"
                                :readOnly="readOnly"
                                
                                :errorCombobox="errorEmployee"
                                :title="titleEmployee"
                                
                                :listFields="listFieldEmployee"
                                :datas="listEmployee"
                                
                                inputText="FullName"
                                :propertyCompare="account.EmployeeId"
                                keySearch="EmployeeId"

                                @onChangeValueKeySearch ="changeIdEmployee"
                                @input="changeFullName"
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
                                        <BaseComboboxNormal label="Người liên hệ" placeholder="Xưng hô"
                                            v-model="account.Prefix"
                                            :readOnly="readOnly"
                                            :datas="listDataPrefix"
                                           
                                        />
                                    </div>
                                    <div class="tab-two-right" style="width:68%">
                                        <BaseInput typeInput="input" placeholder="Họ và tên" 
                                            v-model="account.EinvoiceContactName"
                                            :readOnly="readOnly"
                                        />
                                    </div>

                                </div>
                                <div class="tab-one-row">
                                    <BaseInput typeInput="input" placeholder="Email" 
                                        v-model="account.EinvoiceContactEmail"
                                        :readOnly="readOnly"
                                    />
                                </div>
                                <div class="tab-one-row">
                                    <BaseInput typeInput="input" placeholder="Số điện thoại" styleInput="width:40%;" 
                                        v-model="account.EinvoiceContactMobile"
                                        :readOnly="readOnly"
                                    />
                                </div>

                            </div>
                            <div class="tab-right">
                                <BaseInput typeInput="input" label="Đại diện theo PL" placeholder="Đại diện theo PL" title="Đại diện theo pháp luật" 
                                    v-model="account.LegalRepresentative"
                                    :readOnly="readOnly"
                                />
                            </div>
                        </span>
                        <span v-if="tabSelected == 1">
                            <div>
                                <div class="tab-only-one" v-if="isShowPaymentTerm">
                                    <BaseComboboxNormal label="Điều khoản thanh toán" styleComboboxNormal="width:204px; margin-right:10px" styleDataCombobox="width:460px;"
                                        :isButtonAdd="true"
                                        v-model="account.PaymentTermName"
                                        :isComboboxTable="true"
                                        :readOnly="readOnly"
                                        
                                        :errorCombobox="errorPaymentTerm"
                                        :title="titlePaymentTerm"
                                        
                                        :listFields="listFieldPaymentTerm"
                                        :datas="listPaymentTerm"
                                        
                                        inputText="PaymentTermName"
                                        :propertyCompare="account.PaymentTermId"
                                        keySearch="PaymentTermId"

                                        @onChangeValueKeySearch ="changeIdPaymentTerm"
                                        @input="changePaymentTermName"
                                    />
                                    <BaseInput typeInput="input" label="Số ngày được nợ" :isNumber="true" styleInput="margin-right:10px;" 
                                        v-model="account.DueTime"
                                        :readOnly="readOnly"
                                    />
                                    <BaseInput typeInput="input" label="Số nợ tối đa" :isNumber="true" 
                                        v-model="account.MaximizeDebtAmount"
                                        :readOnly="readOnly"
                                    />
                                </div>
                                <div class="tab-only-one">
                                     <BaseComboboxNormal label="Tài khoản công nợ phải trả" styleComboboxNormal="margin-top: 10px; width:204px" styleDataCombobox="width:360px;"
                                        v-model="account.PayAccountName"
                                        :isComboboxTable="true"
                                        :readOnly="readOnly"
                                        
                                        :errorCombobox="errorPayAccount"
                                        :title="titlePayAccount"
                                        
                                        :listFields="listFieldPayAccount"
                                        :datas="listPayAccount"
                                        
                                        inputText="PayAccountName"
                                        :propertyCompare="account.PayAccountId"
                                        keySearch="PayAccountId"

                                        @onChangeValueKeySearch ="changeIdPayAccount"
                                        @input="changePayAccountName"
                                    />
                                </div>
                              
                            </div>
                        </span>
                        <span v-if="tabSelected == 2">
                            <div style="width: 100%">
                                 <BaseTableInsert
                                    v-model ="listAccountObjectBankAccount"
                                    :listFields="listFieldBank"
                                    :readOnly="readOnly"             
                                />
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
                                    <BaseTableInsert
                                        v-model ="listAccountObjectShippingAddress"
                                        :listFields="listFieldShippingAddress"
                                        :readOnly="readOnly"
                                        :showField="false"          
                                    />
                                </div>
                            </div>

                        </span>
                        <span v-if="tabSelected == 4">
                            <div style="width:100%">
                                <BaseInput typeInput="textarea" styleTextArea="height:215px;" 
                                    v-model="account.Description"
                                    :readOnly="readOnly"
                                />
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
import BaseButton from '@/components/base/BaseButton.vue'
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseRadio from '@/components/base/BaseRadio.vue'
import BaseCheckbox from '@/components/base/BaseCheckbox.vue'
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'
import BaseMess from '@/components/base/BaseMessage.vue'
import BaseComboboxGroup from '@/components/base/BaseComboboxGroup.vue'
import BaseTableInsert from '@/components/base/BaseTableInsert.vue'



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
        BaseMess,
        BaseComboboxGroup,
        BaseTableInsert
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

            // isShowComboboxPrefix:false,//Mặc định ban đầu là đóng
            listDataPrefix:mylib.data.listPrefix,//Dữ liệu chính
            // listDataPrefixTemp:[],//Tạm thời là rỗng
            
            account:{//Viết riêng rẽ từng cái ra dùng để theo dõi trong watch  
                EmployeeId:null,

                PayAccountId:null,
                PayAccountName:null,
                
                AccountObjectCode:null,
                AccountObjectName:null

            },

            titleMessQuestion:mylib.resourcs["VI"].confirmEdit,
            isShowMessQuestion:false,

            isShowMessWarning:false,
            titleMessWarning:"",

            isShowMessInfo:false,
            titleMessInfo:"",

            isShowComboboxEmployee:false,//Trạng thái đầu tiên của combobox
            listEmployee:[],
            listFieldEmployee:mylib.data.listFieldEmployeeCombobox,

            isShowComboboxPayAccount:false,//Trạng thái đầu tiên của combobox
            listPayAccount:null,
            listPayAccountTemp:[],
            listFieldPayAccount:mylib.data.listFieldPayAccountCombobox,

            isShowComboboxPaymentTerm:false,//Trạng thái đầu tiên của combobox
            listPaymentTerm:null,
            listPaymentTermTemp:[],
            listFieldPaymentTerm:mylib.data.listFieldPaymentTermCombobox,

            listAccountObjectGroup:[],
            // listAccountObjectGroupTemp:[],
            listFieldAccountObjectGroup:mylib.data.listFieldAccountObjectGroupCombobox,

            listAccountGroupSelected:new Array(),//Đầu tiên là mảng rỗng
            textSearchAccountObjectGroup:"",

            errorCode:false,//Lỗi hay không lỗi của code
            titleCode:"",//Title thể hiện là chữ phù hợp

            errorName:false,//Lỗi hay không lỗi của Name
            titleName:"",

            errorEmployee:false,
            titleEmployee:"",

            errorPayAccount:false,
            titlePayAccount:"",

            errorPaymentTerm:false,
            titlePaymentTerm:"",
            
            errorAccountObjectGroup:false,
            titleAccountObjectGroup:"",

            listFieldBank:mylib.data.listFieldBank,
            listAccountObjectBankAccount: [],

            listFieldShippingAddress:mylib.data.listFieldShippingAddress,
            listAccountObjectShippingAddress: [],

            isShowEmployee: false,
            isShowPaymentTerm:false,
            isShowPayAccount:false,
            isShowDropDownAccountObjectGroup:false,
            
        }
    },
    async created(){
        var me = this;
        me.$parent.isShowLoading = true;//Thực hiện show loading

        if(me.editMode == mylib.misaEnum.editMode.View){//Nếu nó thuộc kiểu xem thì sẽ vô hiệu hóa các ô lại
            me.readOnly = true;
        }

        //Cần phải viết như này để nó không bind từ detail ảnh hưởng đến table
        me.account= await MyFunction.sameObject(me.accountTable);

        //Thực hiện gán giá trị cho 
        
    },
    async mounted() {
        this.$refs.TaxCode.focus() //Tập trung vào ô mã đầu tiên
        
        await this.getListPayAccount()//Thực hiện gán dữ liệu cho listPayAccount phục vụ cho combobox
        await this.getListPaymentTerm()//Thực hiện gán dữ liệu  phục vụ cho combobox
        await this.getListEmployee()//Thực hiện gán dữ liệu cho listEmployee phục vụ cho combobox
        await this.getListAccountObjectGroup();//Thực hiện gián dữ liệu cho listAccountObjectGroup phục vụ cho combobox
        //Thực hiện gán giá trị cho listAccountObjectBankAccount,listShipdress
        this.getValueJsontoArrayAccount();
        
        this.isShowEmployee = true;//Thực hiện hiện html
        this.isShowPaymentTerm = true;//Thực hiện hiện html
        this.isShowPayAccount = true;//Thực hiện hiện html

        //Thực hiện cắt chuỗi trong accountgrouplist để lấy ra gán vào mảng list để dễ thực hiện làm việc
        this.listAccountGroupSelected = this.cutStrings(this.account.AccountObjectGroupListId);
        this.isShowDropDownAccountObjectGroup = true;

        this.$parent.isShowLoading = false;
    },
    
    watch:{  
        /**
         * Thực hiện theo dõi AccountObjectCode
         * CreatedBy: HoaiPT(03/03/2021)
         */
        'account.AccountObjectCode'(valueNew){
            var me = this;
            if(valueNew !=null){
                 if(valueNew.trim()==""){//Nếu mà nó để trống thì báo lỗi
                    me.errorCode = true;
                    me.titleCode = mylib.resourcs["VI"].notNullCode;
                }else{//Còn nếu mà không trống thì không báo lỗi gì cả
                    me.errorCode = false;
                    me.titleCode = "";
                }
            }    
        },
         /**
         * Thực hiện theo dõi AccountObjectName
         * CreatedBy: HoaiPT(03/03/2021)
         */
        'account.AccountObjectName'(valueNew){
            var me = this;
                if(valueNew !=null ){//Nếu tồn tại
                    if(valueNew.trim()==""){//Nếu mà nó để trống thì báo lỗi
                    me.errorName = true;
                    me.titleName = mylib.resourcs["VI"].notNullName;
                }else{//Còn nếu mà không trống thì không báo lỗi gì cả
                    me.errorName = false;
                    me.titleName = "";
                }
            }
        }
        
    },
    methods: {
        changeSearchTextAccountGroup(){
            this.errorAccountObjectGroup = false;
            this.titleAccountObjectGroup ="";
        },
        changeListAccountGroupSelected(data){
            this.listAccountGroupSelected = data;
        },
        changePayAccountName(){
            this.errorPayAccount = false;
            this.titlePayAccount ="";
            this.account.PayAccountId = null;
        },

        changeIdPayAccount(id){
             this.account.PayAccountId = id;
        },
        changePaymentTermName(){
            this.errorPaymentTerm = false;
            this.titlePaymentTerm ="";
            this.account.PaymentTermId = null;
        },
        changeIdPaymentTerm(id){
            this.account.PaymentTermId = id;
        },
        changeFullName(){
            this.errorEmployee = false;
            this.titleEmployee ="";
            this.account.EmployeeId = null;
        },
        changeIdEmployee(id){
            this.account.EmployeeId = id;
        },
        /**
         * Thực hiện chuyển đổi giá trị AccountObjectBankAccount để cho data base nhận được đồng thời xóa bỏ đối tượng rỗng
         * CreatedBy: HoaiPT(05/03/2022) 
         * */ 
        setValueArraytoJsonAccount(){
            var me =this;
            me.account.AccountObjectBankAccount = me.formatArrayToJson(me.listAccountObjectBankAccount);
            me.account.AccountObjectShippingAddress = me.formatArrayToJson(me.listAccountObjectShippingAddress);
        },    
        /**
         * Thực hiện gán giá trị cho listAccountObjectBankAccount
         * CreatedBy: HoaiPT(05/03/2022)
         */
        async getValueJsontoArrayAccount(){
            var me = this;
            me.listAccountObjectBankAccount = await me.formatJsonToArray(me.account.AccountObjectBankAccount);
            me.listAccountObjectShippingAddress = await me.formatJsonToArray(me.account.AccountObjectShippingAddress);

        },
        /**
         * Thực hiện hành động khi click vào nút có của form hỏi bạn có muốn đóng không
         * CreatedBy: HoaiPT(05/03/2022)
         */
        btnYesQuestion(){
            var me =this;
            me.isShowMessQuestion = false;//Đóng form question

            me.btnSave(1);//Thực hiện hành động Cất
        },
        /**
         * Hành động khi ấn vào nút (Cất) hoặc (Cất và Thêm)
         *CreatedBy: HoaiPT(03/03/2022)
         */
        async  btnSave(value) {
            try {
                var me = this;
                //DO XẢY RA BẤT ĐỒNG BỘ NÊN MỚI PHẢI VIẾT DÀI NHƯ NÀY
                if(! me.validateNotNull()){ //Kiểm tra những trường không được để trống nếu để trống thì return luôn
                    return;
                }
                if(!me.validateFormatAccountObjectCode()){ //Kiểm tra định dạng của mã code
                    return;
                }
                if(!me.validateAccountObjectGroup()){
                    return;
                }
                if(!me.validateEmployee()){//Kiểm tra mã nhân viên mua hàng
                    return;
                }
                if(!me.validatePaymentTerm()){//Kiểm tra mã điều khoản
                    return;
                }
                if(!me.validatePayAccount()){//Kiểm tra mã tài khoản công nợ
                    return;
                }
                let temp= me.listAccountGroupSelected.join(",");
                me.account.AccountObjectGroupListId = temp;
                
                me.setValueArraytoJsonAccount();//Gián giá trị thích hợp cho shiperAddress, bankAccount

                switch (me.editMode) {
                    case mylib.misaEnum.editMode.Add: //Thực hiện thêm mới
                        await axios.post('https://localhost:44338/api/v1/AccountObjects', me.account)
                            .then(function () {
                                me.checkAction(value);
                            })
                            .catch(function () {
                                me.openWarning();
                            })
                        break;
                    case mylib.misaEnum.editMode.Edit: //Thực hiện sửa
                        await axios.put(`https://localhost:44338/api/v1/AccountObjects/${me.account.AccountObjectId}`, me.account)
                            .then(function () {
                                me.checkAction(value);
                            })
                            .catch(function () {
                                me.openWarning();
                            })
                        break;
                    case mylib.misaEnum.editMode.View: //Thực hiện xem
                        me.titleMessInfo = mylib.resourcs["VI"].noActionEvery;
                        me.isShowMessInfo = true;
                        break;
                    default:
                        alert(mylib.resourcs["VI"].errorMsg);
                        break;
                }
            } catch {
                console.error(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện kiểm tra ô input nhóm nhà cung cấp
         * CreatedBy: HoaiPT(03/03/2022)
         */
        validateAccountObjectGroup(){
            var me = this;
            if(me.textSearchAccountObjectGroup.trim()!=""){
                me.errorAccountObjectGroup = true;
                me.titleAccountObjectGroup = mylib.resourcs["VI"].notExistAccountObjectGroupId;
                me.titleMessInfo = mylib.resourcs["VI"].notExistAccountObjectGroupId;
                me.isShowMessInfo = true;
                return false;
            }
            return true;
        },
        /**
         * Thực hiện kiểm tra ô input điều khoản
         * CreatedBy: HoaiPT(03/03/2022)
         */
        validatePaymentTerm(){
            var me = this;
            if(me.account.PaymentTermId == null &&me.account.PaymentTermName != null){//Nếu mà không tồn tại mã
                if(me.account.PaymentTermName.trim()!=""){//Nếu mà bằng rỗng thì cũng cho qua
                    me.errorPaymentTerm = true;
                    me.titlePaymentTerm = mylib.resourcs["VI"].notExistPaymentTermId;
                    me.titleMessInfo = mylib.resourcs["VI"].notExistPaymentTermId;
                    me.isShowMessInfo = true;
                    return false;//Nếu mà tồn tại giá trị thì không cho qua
                }
            }
            return true;//Cho qua
        },
        /**
         * Thực hiện kiểm tra ô input tài khoản công nợ
         * CreatedBy: HoaiPT(03/03/2022)
         */
        validatePayAccount(){
            var me = this;
            if(me.account.PayAccountId == null && me.account.PayAccountName != null){//Nếu mà không tồn tại mã    
                if(me.account.PayAccountName.trim()!=""){//Nếu mà bằng rỗng thì cũng cho qua
                    me.errorPayAccount = true;
                    me.titlePayAccount = mylib.resourcs["VI"].notExistPayAccountId;
                    me.titleMessInfo = mylib.resourcs["VI"].notExistPayAccountId;
                    me.isShowMessInfo = true;
                    return false;//Nếu mà tồn tại giá trị thì không cho qua
                }
            }
            return true;//Cho qua
        },
        /**
         * Thực hiện kiểm tra ô input nhân viên mua hàng
         * CreatedBy: HoaiPT(03/03/2022)
         */
        validateEmployee(){
            var me = this;
            if(me.account.EmployeeId == null && me.account.FullName != null){//Nếu mà không tồn tại mã    
                if(me.account.FullName.trim()!=""){//Nếu mà FullName bằng rỗng thì cũng cho qua
                    me.errorEmployee = true;
                    me.titleEmployee = mylib.resourcs["VI"].notExistEmployeeId;
                    me.titleMessInfo = mylib.resourcs["VI"].notExistEmployeeId;
                    me.isShowMessInfo = true;
                    return false;//Nếu mà tồn tại giá trị thì không cho qua
                } 
            }
            return true;//Cho qua
        },
        /**
         * Thực hiện validate Code xem có chuẩn không
         * CreatedBy: HoaiPT(03/03/2022)
         */
        validateFormatAccountObjectCode() {
            var me = this;
            let temp = /^NCC[0-9]{5}$/.test(me.account.AccountObjectCode);
            if (temp == true)return true;
            else{
                me.errorCode = true;
                me.titleCode = mylib.resourcs["VI"].errorFormatCode;
                me.titleMessInfo = mylib.resourcs["VI"].errorFormatCode;
                me.isShowMessInfo = true;
                return false;
            }       
        },

        /**
         * Thực hiện kiểm tra những ô not null
         * CreatedBy: HoaiPT(03/03/2022)
         */
        validateNotNull(){
            var me = this;
            let titleTemp = "";
            if(me.account.AccountObjectCode.trim()==""){
                me.errorCode = true;
                me.titleCode = mylib.resourcs["VI"].notNullCode;
                titleTemp +="Mã";
            }
            if(me.account.AccountObjectName == null || me.account.AccountObjectName.trim()==""){
                me.errorName = true;
                me.titleName = mylib.resourcs["VI"].notNullName;
                titleTemp += titleTemp !=""? ", Tên": " Tên";
            }
            if(titleTemp=="")return true;
            else{
                me.titleMessInfo = titleTemp + mylib.resourcs["VI"].notNullAll;
                me.isShowMessInfo = true;
                return false;
            }
        },
        /**
         * Mở form cảnh báo khi có lỗi
         *CreatedBy: HoaiPT(03/03/2022)
         */
        openWarning(){
            var me = this;
            me.titleMessWarning =  `Mã  nhân viên <${me.account.AccountObjectCode}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.`;
            me.isShowMessWarning = true;
            me.errorCode = true;//Thể hiện viền đỏ của ô Code,
            me.titleCode = "Mã đã tồn tại!";
        },
        /**
         * Thực hiện kiểm tra xem là hành động (Cất) | (Cất và Thêm) để thực hiện phù hợp
         * 1: Cất
         * 2: Cất và Thêm
         *CreatedBy: HoaiPT(03/03/2022)
         */
        async checkAction(value) {
            var me = this;
            switch (value) {
                case 1: //Nếu là cất
                    me.$parent.isShowAccountDetail = false;//Thực hiện đóng form 
                    await me.$parent.showData();//Load lại dữ liệu
                    break;
                case 2: //Nếu là cất và thêm 
                    me.$parent.editModeTable = mylib.misaEnum.editMode.Add; //Đây là hành động thêm mới
                    await me.$parent.showData();//Load lại dữ liệu
                    await me.resetFormDetail(); //reset form 
                    await me.getCodeNewDetail();//Lấy mã mới  và đồng thời form message question hay không khi click vào nút tích ở góc bên phải trên cùng màn hình
                    break;
                default:
                    break;
            }
        },
        /**
         * Thực hiện lấy mã mới cho account
         * CreatedBy:HoaiPT(03/03/2022)
         */
        async getCodeNewDetail(){
            var me = this;
            me.$parent.accountSelected={};//Phục vụ cho mục đích nếu có hiện form message question hay không
            await me.$parent.getCodeNew(); //Lấy ở data mã code mới
            me.account.AccountObjectCode = me.$parent.accountSelected.AccountObjectCode;
        },
        /**
         * Làm mới form detail
         *CreatedBy: HoaiPT(03/03/2022)
         */
        resetFormDetail() {
            var me = this;
            me.textSearchAccountObjectGroup="";//Ô tìm kiếm trong searchgroud == rỗng,
            me.listAccountGroupSelected=[];//gán đang lựa chọn bằng []
            me.lli

            me.listAccountObjectBankAccount = [{}];//Đưa về [] với mặc định là có một phần tử rỗng
            me.listAccountObjectShippingAddress =[{}];//Tương tự như trên

            me.tabSelected = 0;//Trở về đầu tiên


            //Làm mới toàn bộ để lại mã mới tự tăng
            for (var propName in me.account) {
                me.account[propName] = null;
            }
        },
        /**
         * Thực hiện khi click vào nút đóng nhỏ của mỗi item AccountObjectGroup ở trong ô
         * Đó là thực hiện xóa nó đi khỏi mảng
         * CreatedBy: HoaiPT(02/03/2022)
         */
        // removeOneAccountObjectGroup({index}){
        //     this.listAccountGroupSelected.splice(index, 1);
        // },
        // /**
        //  * Thực hiện khi click vào nút dropdow và dữ liệu bằng đúng dữ liệu tất cả 
        //  * CreatedBy: HoaiPT(02/03/2022)
        //  */
        // btnClickDropdownAccountObjectGroup(){
        //     this.listAccountObjectGroupTemp = this.listAccountObjectGroup;
        //     this.isShowDropDownAccountObjectGroup = !this.isShowDropDownAccountObjectGroup;
        // },
        /**
         * Thực hiện khi click item bất kì trong dữ liệu data có thể thực hiện xóa hoặc là add thêm vào
         * CreatedBy: HoaiPT(02/03/2022)
         */
        // btnSelectItemAccountObjectGroup({object}){
        //     console.log('object:', object);
        //     var me = this;
        //     if(me.existValueInArray2(me.listAccountGroupSelected,object.AccountObjectGroupCode)){
        //         me.listAccountGroupSelected = me.removeValueInArray(me.listAccountGroupSelected,object.AccountObjectGroupCode);
        //     }else{
        //         me.listAccountGroupSelected.push(object.AccountObjectGroupCode);
        //     }
        // },
        
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
         * Thực hiện khi khi thay đổi giá trị của tổ chức hay cá nhân ấy nhưng hiện tại chỉ cần vẽ thôi
         * CreatedBy: HoaiPT(28/02/2021)
         */
        changeTypeDetail(){},
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
        async getListAccountObjectGroup() {
            try {
                var me = this;
                await axios.get('https://localhost:44338/api/v1/AccountObjectGroups')
                    .then(function(res) {
                        me.listAccountObjectGroup = res.data;
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện lấy những cái này từ file js
         * CreatedBy:HoaiPT(02/03/2022)
         */
        existValueInArray2:MyFunction.existValueInArray2,
        selectFilterObject:MyFunction.selectFilterObject,
        sameObject:MyFunction.sameObject,
        cutStrings:MyFunction.cutStrings,
        removeValueInArray:MyFunction.removeValueInArray,
        formatJsonToArray:MyFunction.formatJsonToArray,
        formatArrayToJson: MyFunction.formatArrayToJson,
    }
}
</script>

<style scoped>
@import url(../../style/view/account_object/account-detail.css);
</style>
