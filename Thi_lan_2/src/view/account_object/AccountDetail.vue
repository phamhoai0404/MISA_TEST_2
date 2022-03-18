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
                                    <BaseComboboxNormal label="Điều khoản thanh toán" styleComboboxNormal="width:204px; margin-right:10px" styleDataCombobox="width:460px; "
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
                                 <BaseTableInsert styleTable="max-height:145px !important; overflow-y: auto;"
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
                                        <BaseComboboxNormal label="Vị trí địa lý" placeholder="Quốc gia"
                                            v-model="account.Country" :showField ="false"
                                            :isComboboxTable="true"
                                            :readOnly="readOnly"
                                            :errorCombobox="errorCountry"
                                            :title="titleCountry"
                                            

                                            :listFields="listFieldCountry"
                                            :datas="listCountrySource"

                                            inputText="LocationName"
                                            :propertyCompare="countryIdTemp"
                                            keySearch="LocationId"

                                            @onChangeValueKeySearch ="changeIdCountry"
                                            @input="changeInputCountry"
                                        />
                                    </div>
                                    <div class="tab-two-right" style="width:48%">
                                        <BaseComboboxNormal placeholder="Tỉnh/Thành phố"
                                            v-model="account.ProvinceOrCity"
                                            :isComboboxTable="true" :showField ="false"
                                            :readOnly="readOnly"
                                            :errorCombobox="errorProvinceOrCity"
                                            :title="titleProvinceOrCity"
                                            :isShowData="isShowDataProvinceOrCity"

                                            :listFields="listFieldProvinceOrCity"
                                            :datas="listProvinceOrCityTemp"

                                            inputText="LocationName"
                                            :propertyCompare="provinceOrCityIdTemp"
                                            keySearch="LocationId"

                                            @onChangeValueKeySearch ="changeIdProvinceOrCity"
                                            @input="changeInputProvinceOrCity"
                                            @updateIsShowData ="updateIsShowProvinceOrCity"
                                        />
                                    </div>
                                </div>
                                <div class="tab-two-row">
                                    <div class="tab-two-right" style="width:48%">   
                                        <BaseComboboxNormal placeholder="Quận/Huyện"
                                            v-model="account.District"
                                            :isComboboxTable="true" :showField ="false"
                                            :readOnly="readOnly"
                                            :errorCombobox="errorDistrict"
                                            :title="titleDistrict"
                                            :isShowData="isShowDataDistrict"

                                            :listFields="listFieldDistrict"
                                            :datas="listDistrictTemp"

                                            inputText="LocationName"
                                            :propertyCompare="districtIdTemp"
                                            keySearch="LocationId"

                                            @onChangeValueKeySearch ="changeIdDistrict"
                                            @input="changeInputDistrict"
                                            @updateIsShowData ="updateIsShowDistrict"
                                        />
                                    </div>
                                    <div class="tab-two-right" style="width:48%">
                                        <BaseComboboxNormal placeholder="Xã/Phường"
                                            v-model="account.WardOrCommune"
                                            :isComboboxTable="true" :showField ="false"
                                            :readOnly="readOnly"
                                            :errorCombobox="errorWardOrCommune"
                                            :title="titleWardOrCommune"
                                            :isShowData ="isShowDataWardOrCommune"

                                            :listFields="listFieldWardOrCommune"
                                            :datas="listWardOrCommuneTemp"

                                            inputText="LocationName"
                                            :propertyCompare="wardOrCommuneIdTemp"
                                            keySearch="LocationId"

                                            @onChangeValueKeySearch ="changeIdWardOrCommune"
                                            @input="changeInputWardOrCommune"
                                            @updateIsShowData ="updateIsShowWardOrCommune"
                                        />
                                    </div>
                                </div>
                            </div>
                            <div class="tab-right">
                                <div class="tab-group-title">
                                   <div class="tab-title-child">Địa chỉ giao hàng</div>
                                    <BaseCheckbox label="Giống địa chỉ nhà cung cấp" id="address-same" styleCheckbox="padding-left:18px" @clickCheckbox="btnCheckboxAddressShip" />
                                </div>
                                <div class="tab-content-table">
                                    <BaseTableInsert styleTable="max-height:120px !important;  overflow-y: auto;"
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


import * as location from '@/js/location.js'
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
                AccountObjectCode:null,
                AccountObjectName:null,
                Address:null
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
            listFieldPayAccount:mylib.data.listFieldPayAccountCombobox,

            isShowComboboxPaymentTerm:false,//Trạng thái đầu tiên của combobox
            listPaymentTerm:null,
            listFieldPaymentTerm:mylib.data.listFieldPaymentTermCombobox,

            listAccountObjectGroup:[],
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

            listCountrySource:location.resourcs.countries,
            listProvinceOrCitySource:location.resourcs.cities,//Nguồn chính của thành phố
            listProvinceOrCityTemp:[],//Thực sự truyền vào mỗi khi thay đổi giá trị của cha
            listDistrictSource:location.resourcs.district,//Nguồn chính của Quận huyện
            listDistrictTemp:[],//Thực sự truyền vào mỗi khi thay đổi giá trị của cha
            listWardOrCommuneSource:location.resourcs.wardOrCommune,//Nguồn chính của xã phường
            listWardOrCommuneTemp:[],//Thực sự truyền vào mỗi khi thay đổi giá trị của cha
            listFieldProvinceOrCity: mylib.data.listFieldProvinceOrCity,//Field của thành phố
            listFieldCountry: mylib.data.listFieldCountry,//Field của quốc gia
            listFieldDistrict: mylib.data.listFieldDistrict,//Field của quận huyện
            listFieldWardOrCommune: mylib.data.listFieldWardOrCommune,//Field của xã phường
            
            countryIdTemp:null,//Các biến id giả để css thôi vì trong csdl không có
            provinceOrCityIdTemp:null,//Các biến id giả để css thôi vì trong csdl không có
            districtIdTemp:null,//Các biến id giả để css thôi vì trong csdl không có
            wardOrCommuneIdTemp:null,//Các biến id giả để css thôi vì trong csdl không có

            errorCountry:false,
            titleCountry:"",
            errorProvinceOrCity:false,
            titleProvinceOrCity:"",
            errorDistrict:false,
            titleDistrict:"",
            errorWardOrCommune:false,
            titleWardOrCommune:"",
            isShowDataWardOrCommune:false,
            isShowDataDistrict:false,
            isShowDataProvinceOrCity:false,
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
        console.log(this.$refs);
        this.$refs.TaxCode.focus() //Tập trung vào ô mã đầu tiên
        
        await this.getListPayAccount()//Thực hiện gán dữ liệu cho listPayAccount phục vụ cho combobox
        await this.getListPaymentTerm()//Thực hiện gán dữ liệu  phục vụ cho combobox
        await this.getListEmployee()//Thực hiện gán dữ liệu cho listEmployee phục vụ cho combobox
        await this.getListAccountObjectGroup();//Thực hiện gián dữ liệu cho listAccountObjectGroup phục vụ cho combobox
        //Thực hiện gán giá trị cho listAccountObjectBankAccount,listShipdress
        await this.getValueJsontoArrayAccount();
        
        this.isShowEmployee = true;//Thực hiện hiện html
        this.isShowPaymentTerm = true;//Thực hiện hiện html
        this.isShowPayAccount = true;//Thực hiện hiện html

        //Thực hiện cắt chuỗi trong accountgrouplist để lấy ra gán vào mảng list để dễ thực hiện làm việc
        this.listAccountGroupSelected = this.cutStrings(this.account.AccountObjectGroupListId);
        this.isShowDropDownAccountObjectGroup = true;

        //Thực hiện lấy dữ liệu cho địa chỉ phù hợp
        await this.getDataAddress();

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
        },
        countryIdTemp(valueNew){
            this.listProvinceOrCityTemp = this.listProvinceOrCitySource.filter(item=> item.ParentId == valueNew);
        },
        provinceOrCityIdTemp(valueNew){
            this.listDistrictTemp = this.listDistrictSource.filter(item => item.ParentId == valueNew);
        },
        districtIdTemp(valueNew){
            this.listWardOrCommuneTemp = this.listWardOrCommuneSource.filter(item => item.ParentId == valueNew);
        },
        'account.Address'(valueNew, valueOld){
            // console.log("vào đây 1");
            if(document.getElementById('address-same')){
                const item = document.getElementById('address-same');
                if(item.checked == true){
                    // console.log("vào đây 2");
                    if(this.listAccountObjectShippingAddress[0].AddressShipName == valueOld)
                    {
                        // console.log("vào đây 3");
                        this.listAccountObjectShippingAddress[0].AddressShipName = valueNew;
                    }
                }
            }
            
        }
    },
    methods: {
        /**
         * Thực hiện cập nhật tình trạng dropdown data vào WardOrCommune là đóng hay mở
         * CreadBy: HoaiPT(17/03/2022)
         */
        updateIsShowWardOrCommune(status){
            this.isShowDataWardOrCommune = status;
        },
        /**
         * Thực hiện cập nhật tình trạng dropdown data vào District là đóng hay mở
         * CreadBy: HoaiPT(17/03/2022)
         */
        updateIsShowDistrict(status){
            this.isShowDataDistrict = status;
        },
        /**
         * Thực hiện cập nhật tình trạng dropdown data vào ProvinceOrCity là đóng hay mở 
         * CreadBy: HoaiPT(17/03/2022)
         */
        updateIsShowProvinceOrCity(status){
            this.isShowDataProvinceOrCity = status;
        },
        /**
         * Thực hiện khi thay đổi giá trị input WardOrCommune
         * CreadBy: HoaiPT(17/03/2022)
         */
        changeInputWardOrCommune(){
            this.wardOrCommuneIdTemp = null;
            this.errorWardOrCommune = false;//Nếu có viền đỏ thì bỏ
            this.titleWardOrCommune = "";//Và title cũng bỏ
        },
        /**
         * Thực hiện thay đổi giá trị Id khi select WardOrCommune
         * CreadBy: HoaiPT(17/03/2022)
         */
        changeIdWardOrCommune(object){
            this.wardOrCommuneIdTemp = object.LocationId;
        },
        /**
         * Thực hiện khi thay đổi giá trị input District
         * CreadBy: HoaiPT(17/03/2022)
         */
        changeInputDistrict(){
            this.districtIdTemp = null;
            this.errorDistrict = false;//Nếu có viền đỏ thì bỏ
            this.titleDistrict = "";//Và title cũng bỏ
            this.listWardOrCommuneTemp =[];

            this.account.WardOrCommune ="";
            this.isShowDataWardOrCommune = false;

            this.wardOrCommuneIdTemp = null;
        },
        /**
         * Thực hiện thay đổi giá trị Id khi select District
         * CreadBy: HoaiPT(17/03/2022)
         */
        changeIdDistrict(object){
            this.districtIdTemp = object.LocationId;
        },
        /**
         * Thực hiện khi thay đổi giá trị input ProvinceOrCity
         * CreadBy: HoaiPT(17/03/2022)
         */
        changeInputProvinceOrCity(){
            this.provinceOrCityIdTemp = null;
            this.errorProvinceOrCity = false;//Nếu có viền đỏ thì bỏ
            this.titleProvinceOrCity = "";//Và title cũng bỏ
            this.listDistrictTemp =[];
            this.listWardOrCommuneTemp =[];

            this.account.District="";
            this.isShowDataDistrict = false;
            this.account.WardOrCommune ="";
            this.isShowDataWardOrCommune = false;
            
            this.districtIdTemp = null;
            this.wardOrCommuneIdTemp = null;
            
        },
        /**
         * Thực hiện thay đổi giá trị Id khi select ProvinceOrCity
         * CreadBy: HoaiPT(17/03/2022)
         */
        changeIdProvinceOrCity(object){
            this.provinceOrCityIdTemp = object.LocationId;
        },
        /**
         * Thực hiện khi thay đổi giá trị input Country
         * CreadBy: HoaiPT(17/03/2022)
         */
        changeInputCountry(){
            this.countryIdTemp = null;
            this.errorCountry = false;//Nếu có viền đỏ thì bỏ viền đỏ
            this.titleCountry = "";//Có title  thì bỏ title

            this.listProvinceOrCityTemp =[];
            this.listDistrictTemp =[];
            this.listWardOrCommuneTemp =[];
            
            this.account.ProvinceOrCity="";
            this.isShowDataProvinceOrCity = false;
            this.account.District="";
            this.isShowDataDistrict = false;
            this.account.WardOrCommune ="";
            this.isShowDataWardOrCommune = false;
            
            this.provinceOrCityIdTemp = null;
            this.districtIdTemp = null;
            this.wardOrCommuneIdTemp = null;
        },
        /**
         * Thực hiện thay đổi giá trị Id khi select Country
         * CreadBy: HoaiPT(17/03/2022)
         */
        changeIdCountry(object){
            this.countryIdTemp = object.LocationId;
        },
        /**
         * Thực hiện khi click vào checkbox giống địa chỉ của nhà cung cấp
         * CreatedBy: HoaiPT(13/03/2022)  
         */
        btnCheckboxAddressShip({id}){
            var me = this;
            const item = document.getElementById(id);
            if(item.checked == true){//Nếu đang chọn
                if(me.account.Address !=null ){//Nếu địa chỉ tồn tại
                    let tempValue = me.account.Address.trim();
                    if(tempValue !=""){//Nếu địa chỉ khác ""
                        if( !MyFunction.valueInArray(me.listAccountObjectShippingAddress, "AddressShipName",tempValue)){//Giá trị này chưa tồn tại trong list shipping Address
                            let tempObject ={};
                            tempObject.AddressShipName = tempValue;
                            me.listAccountObjectShippingAddress.unshift(tempObject);//Thì add lên đầu tiên của list shipping address
                        }
                    }
                }
            }
        },
        /**
         * Thực hiện xóa bỏ viền đỏ, title bằng "" khi mà có lỗi khi nhập dòng chữ ở ô input trong group
         * CreatedBy: HoaiPT(05/03/2022) 
         */
        changeSearchTextAccountGroup(){
            this.errorAccountObjectGroup = false;
            this.titleAccountObjectGroup ="";
        },
        /**
         * Upload lại dữ liệu từ con bắn về cho cha
         * CreatedBy: HoaiPT(05/03/2022) 
         */
        changeListAccountGroupSelected(data){
            this.listAccountGroupSelected = data;
        },
        /**
         * Thực hiện thay đổi xóa bỏ lỗi viền đỏ, xóa bỏ title, gán id = null
         * CreatedBy: HoaiPT(05/03/2022) 
         */
        changePayAccountName(){
            this.errorPayAccount = false;
            this.titlePayAccount ="";
            this.account.PayAccountId = null;
        },
        /**
         * Thực hiện gán giá trị mới cho Id của PayAccountId khi select item mới
         * CreatedBy: HoaiPT(05/03/2022) 
         */
        changeIdPayAccount(object){
             this.account.PayAccountId = object.PayAccountId;
        },
        /**
         * Thực hiện xóa bỏ lỗi viền đỏ, xóa bỏ title, gán id bằng null khi mà thay  đổi giá trị input tìm kiếm trong combobox
         * CreatedBy: HoaiPT(05/03/2022) 
         */
        changePaymentTermName(){
            this.errorPaymentTerm = false;
            this.titlePaymentTerm ="";
            this.account.PaymentTermId = null;
        },
        /**
         * Thực hiện khi thay đổi select gán lại giá trị id mới cho paymentTerm
         * CreatedBy: HoaiPT(05/03/2022) 
         */
        changeIdPaymentTerm(object){
            this.account.PaymentTermId = object.PaymentTermId;
        },
        /**
         * Thực hiện khi thay đổi trong dòng input của FullName thì xóa bỏ lỗi viền đỏ, xóa bỏ title lỗi, gián id bằng null
         * CreatedBy: HoaiPT(05/03/2022) 
         */
        changeFullName(){
            this.errorEmployee = false;
            this.titleEmployee ="";
            this.account.EmployeeId = null;
        },
        /**
         * Thực hiện gián Id mới cho nhân viên được chọn
         * CreatedBy: HoaiPT(05/03/2022) 
         */
        changeIdEmployee(object){
            this.account.EmployeeId = object.EmployeeId;
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
                if( !me.validateAddress()){//Kiểm tra validate Address
                    return;
                }

                let temp= me.listAccountGroupSelected.join(",");
                me.account.AccountObjectGroupListId = temp;
                
                me.setValueArraytoJsonAccount();//Gián giá trị thích hợp cho shiperAddress, bankAccount

                switch (me.editMode) {
                    case mylib.misaEnum.editMode.Add: //Thực hiện thêm mới
                        await axios.post('https://localhost:44338/api/v1/AccountObjects', me.account)
                            .then(function (res) {
                                if( !res.data.errorCode){ //Không có lỗi thì sẽ vào đây
                                    me.checkAction(value);
                                }else{//Có lỗi thì sẽ vào đây
                                    me.openWarning(res);
                                }  
                            })
                        break;
                    case mylib.misaEnum.editMode.Edit: //Thực hiện sửa
                        await axios.put(`https://localhost:44338/api/v1/AccountObjects/${me.account.AccountObjectId}`, me.account)
                            .then(function (res) {
                                if( !res.data.errorCode){ //Không có lỗi thì sẽ vào đây
                                    me.checkAction(value);
                                }else{//Có lỗi thì sẽ vào đây
                                    me.openWarning(res);
                                }  
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
         * Thực hiện Validate Address
         * CreadBy: HoaiPT(17/03/2022)
         */
        validateAddress(){
            var me = this;
            if(me.account.Country != null){//Nếu mà nó có tồn tại
                if(me.account.Country !="" && me.countryIdTemp == null){//Nếu nó có giá trị mà id vẫn bằng null
                    me.titleCountry = mylib.resourcs["VI"].notCountry;
                    me.errorCountry = true;//Thể hiện viền đỏ ở ô country

                    me.titleMessInfo = mylib.resourcs["VI"].notCountry;
                    me.isShowMessInfo = true;//Hiện message thông báo lỗi
                    return false;
                }
            }
            if(me.account.ProvinceOrCity != null){//Nếu mà nó có tồn tại
                if(me.account.ProvinceOrCity !="" && me.provinceOrCityIdTemp == null){//Nếu nó có giá trị mà id vẫn bằng null
                    me.titleProvinceOrCity = mylib.resourcs["VI"].notProvinceOrCity;
                    me.errorProvinceOrCity = true;

                    me.titleMessInfo = mylib.resourcs["VI"].notProvinceOrCity;
                    me.isShowMessInfo = true;//Hiện message thông báo lỗi
                    return false;
                }
            }

            if(me.account.District != null){//Nếu mà nó có tồn tại
                if(me.account.District !="" && me.districtIdTemp == null){//Nếu nó có giá trị mà id vẫn bằng null
                    me.titleDistrict = mylib.resourcs["VI"].notDistrict;
                    me.errorDistrict = true;

                    me.titleMessInfo = mylib.resourcs["VI"].notDistrict;
                    me.isShowMessInfo = true;//Hiện message thông báo lỗi
                    return false;
                }
            }

            if(me.account.WardOrCommune != null){//Nếu mà nó có tồn tại
                if(me.account.WardOrCommune !="" && me.wardOrCommuneIdTemp == null){//Nếu nó có giá trị mà id vẫn bằng null
                    me.titleWardOrCommune = mylib.resourcs["VI"].notWardOrCommune;
                    me.errorWardOrCommune = true;

                    me.titleMessInfo = mylib.resourcs["VI"].notWardOrCommune;
                    me.isShowMessInfo = true;//Hiện message thông báo lỗi
                    return false;
                }
            }
            return true;
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
        openWarning(res){
            var me = this;
            let tempTitleMessWarning ='';
            switch (res.data.errorCode) {
                case mylib.misaEnum.errorCode.Duplicate:
                    tempTitleMessWarning = `Mã  nhà cung cấp <${me.account.AccountObjectCode}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.`;
                    me.errorCode = true;//Thể hiện viền đỏ của ô Code,
                    me.titleCode = "Mã đã tồn tại!";
                    break;
                case mylib.misaEnum.errorCode.NotFormat:
                    tempTitleMessWarning = `Mã  nhà cung cấp <${me.account.AccountObjectCode}> không đúng định dạng, vui lòng kiểm tra lại.`;
                    me.errorCode = true;//Thể hiện viền đỏ của ô Code,
                    me.titleCode = "Mã không đúng định dạng!";
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
         * Thực hiện lấy giá trị địa chỉ phù hợp từ backend lên và gán
         * CreadBy: HoaiPT(17/03/2022)
         */
        getDataAddress(){
            var me = this;

            //Lấy country
            if(me.account.Country != null){
                for(let i = 0 ; i< me.listCountrySource.length; i++){
                    if(me.account.Country == me.listCountrySource[i].LocationName){
                        me.countryIdTemp = me.listCountrySource[i].LocationId;//Lấy giá trị Id Country css nếu mà nó có
                        break;
                    }
                }
            }else{
                me.countryIdTemp = null;//Nếu nó không có giá trị thì nó bằng null,
            }

            //Lấy ProvinceOrCity
            if(me.account.ProvinceOrCity != null){
                for(let i = 0 ; i< me.listProvinceOrCitySource.length; i++){
                    if(me.account.ProvinceOrCity == me.listProvinceOrCitySource[i].LocationName){
                        me.provinceOrCityIdTemp = me.listProvinceOrCitySource[i].LocationId;//Lấy giá trị Id Country css nếu mà nó có
                        break;
                    }
                }
            }else{
                me.provinceOrCityIdTemp = null;//Nếu nó không có giá trị thì nó bằng null,
            }

            //Lấy District
            if(me.account.District != null){
                for(let i = 0 ; i< me.listDistrictSource.length; i++){
                    if(me.account.District == me.listDistrictSource[i].LocationName){
                        me.districtIdTemp = me.listDistrictSource[i].LocationId;//Lấy giá trị Id Country css nếu mà nó có
                        break;
                    }
                }
            }else{
                me.districtIdTemp = null;//Nếu nó không có giá trị thì nó bằng null,
            }

            //Lấy WardOrCommune
             if(me.account.WardOrCommune != null){
                for(let i = 0 ; i< me.listWardOrCommuneSource.length; i++){
                    if(me.account.WardOrCommune == me.listWardOrCommuneSource[i].LocationName){
                        me.wardOrCommuneIdTemp = me.listWardOrCommuneSource[i].LocationId;//Lấy giá trị Id Country css nếu mà nó có
                        break;
                    }
                }
            }else{
                me.wardOrCommuneIdTemp = null;//Nếu nó không có giá trị thì nó bằng null,
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
