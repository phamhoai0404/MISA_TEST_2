<template>
<div class="popup-detail">
    <div class="popup-top-header">
        <div class="top-header-left">
            <BaseButtonIcon iconClass="btn-clock" />
            <div class="title-top-header-left">Phiếu chi {{tielte}}</div>
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
    <div class="popup-content">
        <div class="content-master">
            <div class="popup-content-left">
                <div class="master-left-one">
                    <div class="left-row-multi">
                        <div style="width:40%; padding-right: 12px;">
                            <BaseComboboxNormal :datas="[]" :isButtonAdd="true" label="Đối tượng" />
                        </div>
                        <div style="width:59%;">
                            <BaseInput typeInput="input" label="Người nhận" />
                        </div>
                    </div>
                    <div class="left-row">
                        <BaseInput typeInput="input" label="Địa chỉ" />
                    </div>
                    <div class="left-row">
                        <BaseInput typeInput="input" label="Lý do" />
                    </div>
                    <div class="left-row-multi">
                        <div style="width:40%; padding-right: 12px;">
                            <BaseComboboxNormal :datas="[]" :isButtonAdd="true" label="Nhân viên" />
                        </div>
                        <div style="width:59%; display: flex;">
                            <BaseInput typeInput="input" label="Kèm theo" :isNumber="true" placeholder="Số lượng" styleInput="width: 40%;" />
                            <div style="padding: 28px 6.5px 0;">Chứng từ gốc</div>
                        </div>
                    </div>
                    <div class="left-row-multi">
                        <div >Tham chiếu</div>
                        <div class="cetera">...</div>
                    </div>
                </div>
                <div class="master-left-two" style="width:185px;">
                    <div class="item-left-two">
                        <BaseInput typeInput="date" label="Ngày hạch toán" v-model="xinh" />
                    </div>
                    <div class="item-left-two">
                        <BaseInput typeInput="date" label="Ngày phiếu chi" v-model="xinh" />
                    </div>
                    <div class="item-left-two" style="padding-bottom: 0px;">
                        <BaseInput typeInput="input" label="Số phiếu chi" />
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
                  <BaseTableInsert
                    v-model ="listAccountObjectShippingAddress"
                    :listFields="listFieldShippingAddress"
                    :readOnly="readOnly"
                    :showField="false"          
                  />
            </div>
        </div>
    </div>

</div>
</template>

<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'
export default {
    components: {
        BaseButtonIcon,
        BaseComboboxNormal,
        BaseInput
    },
    data() {
        return {
            titlePopupDefault: "7. Chi khác",
            titleMoneyDefault:"VND",

            tielte: "PC000125", //Cái này test tí xóa đi
            xinh: "2022-02-28T17:36:35",

        }
    },
}
</script>

<style scoped>
@import url(../../style/view/cash/ca-payment-detail.css);
</style>
