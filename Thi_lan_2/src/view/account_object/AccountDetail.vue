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
                <BaseButtonIcon iconClass="btn-icon-close" @btnClick="btnCloseForm" title="Đóng(ESC)" />
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
                            <BaseInput typeInput="input" label="Nhân viên mua hàng" />
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
                                        <BaseInput typeInput="input" label="Người liên hệ" placeholder="Chưa làm được" />
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
                                    <BaseInput typeInput="input" label="Điều khoản thanh toán" placeholder="Chưa làm được" styleInput="margin-right:10px;" />
                                    <BaseInput typeInput="input" label="Số ngày được nợ" :isNumber="true" styleInput="margin-right:10px;" v-model="account.DueTime"/>
                                    <BaseInput typeInput="input" label="Số nợ tối đa" :isNumber="true" v-model="account.MaximizeDebtAmount"/>
                                </div>
                                <div class="tab-only-one">
                                    <BaseInput typeInput="input" label="Tài khoản công nợ phải trả" styleInput="margin-top:10px;"  placeholder="Chưa làm được"/>
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
</div>
</template>

<script>
import BaseButton from '@/components/base/BaseButton.vue'
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseRadio from '@/components/base/BaseRadio.vue'
import BaseCheckbox from '@/components/base/BaseCheckbox.vue'
// import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'

import BaseInput from '@/components/base/BaseInputNormal.vue'
import * as mylib from '@/js/resourcs.js'

export default {
    components: {
        BaseButton,
        BaseButtonIcon,
        BaseRadio,
        BaseCheckbox,
        BaseInput,
        // BaseComboboxNormal
    },
    props:{
        accountTable:null,//Lấy từ cha gửi vào cho con là Detail
        editMode:mylib.misaEnum.editMode.NoAction,//Mặc định hành động là chưa làm gì cả
    },
    data() {
        return {
            typeDetail: '1',

            tabSelected: 0,
            listTabIndex: mylib.data.listTabIndex,
            readOnly:false,//Thực hiện để mở khóa hay đóng lại các ô input
            
            account:{},
        }
    },
    async created(){
        var me = this;
        //Thiết lập mặc định là có

        if(me.editMode == mylib.misaEnum.editMode.View){//Nếu nó thuộc kiểu xem thì sẽ vô hiệu hóa các ô lại
            me.readOnly = true;
        }
        await me.getAccountTable();
    },
    methods: {
        btnSave(value) {
            alert("value " + value);
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
        changeTypeDetail() {
            // alert("change type detail");
        },
        selectedTabIndex(index) {
            var me = this;
            me.tabSelected = index;
        },
        /**
         * Lấy giá trị của một Account của table gán vào cho form ( có thể là có account hoặc là một rỗng)
         * CreatedBy: HoaiPT(28/02/2022)
         */
        getAccountTable(){
            var me = this;
            for (var propName in me.accountTable) {
                me.account[propName]= me.accountTable[propName];    
            }
        }

    }
}
</script>

<style scoped>
@import url(../../style/view/account_object/account-detail.css);
</style>
