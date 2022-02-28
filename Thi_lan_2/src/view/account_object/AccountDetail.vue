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
                <BaseButtonIcon iconClass="btn-icon-help" @btnClick="action()" title="Giúp(F1)" />
                <BaseButtonIcon iconClass="btn-icon-close" @btnClick="action()" title="Đóng(ESC)" />
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
                                <BaseInput typeInput="input" label="Mã nhà cung cấp" :isRequire="true" />
                            </div>
                        </div>
                        <div class="dialog-one-row">
                            <BaseInput typeInput="input" label="Tên nhà cung cấp" :isRequire="true" />
                        </div>
                        <div class="dialog-one-row">
                            <BaseInput typeInput="textarea" placeholder="VD: Số 82 Duy Tân, Dịch Vọng Hậu, Cầu Giấy, Hà Nội" label="Địa chỉ" />
                        </div>
                    </div>
                    <div class="dialog-one-right">
                        <div class="dialog-two-row">
                            <div class="left-row">
                                <BaseInput typeInput="input" label="Điện thoại" />
                            </div>

                            <div class="right-row">
                                <BaseInput typeInput="input" label="Website" />
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
                                        <BaseInput typeInput="input" placeholder="Họ và tên" />
                                    </div>

                                </div>
                                <div class="tab-one-row">
                                    <BaseInput typeInput="input" placeholder="Email" />
                                </div>
                                <div class="tab-one-row">
                                    <BaseInput typeInput="input" placeholder="Số điện thoại" styleInput="width:40%;" />
                                </div>

                            </div>
                            <div class="tab-right">
                                <BaseInput typeInput="input" label="Đại diện theo PL" placeholder="Đại diện theo PL" title="Đại diện theo pháp luật" />
                            </div>
                        </span>
                        <span v-if="tabSelected == 1">
                            <div>
                                <div class="tab-only-one">
                                    <BaseInput typeInput="input" label="Điều khoản thanh toán" placeholder="Chưa làm được" styleInput="margin-right:10px;" />
                                    <BaseInput typeInput="input" label="Số ngày được nợ" :isNumber="true" styleInput="margin-right:10px;" />
                                    <BaseInput typeInput="input" label="Số nợ tối đa" :isNumber="true" />
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
                                <BaseInput typeInput="textarea" styleTextArea="height:215px;" />
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

import BaseInput from '@/components/base/BaseInputNormal.vue'
import * as mylib from '@/js/resourcs.js'
export default {
    components: {
        BaseButton,
        BaseButtonIcon,
        BaseRadio,
        BaseCheckbox,
        BaseInput
    },
    data() {
        return {
            typeDetail: '1',

            tabSelected: 3,
            listTabIndex: mylib.data.listTabIndex,
        }
    },
    methods: {
        btnSave(value) {
            alert("value " + value);
        },
        btnCloseForm() {
            alert("Đóng form");
        },
        changeTypeDetail() {
            // alert("change type detail");
        },
        selectedTabIndex(index) {
            var me = this;
            me.tabSelected = index;
        }

    }
}
</script>

<style scoped>
@import url(../../style/view/account_object/account-detail.css);
</style>
