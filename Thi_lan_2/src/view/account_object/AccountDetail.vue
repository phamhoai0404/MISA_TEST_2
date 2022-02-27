<template>
<div class="dialog">
    <div class="dialog-content">
        <div class="dialog-header">
            <div class="dialog-title">
                <div class="title">Thông tin nhà cung cấp</div>
                <div class="group-function">
                    <div class="group-radio">
                        <BaseRadio label="Tổ chức" styleRadio="margin-right:20px;" id="organization" name="typeRadioDetail"  valueReal="1"  @change="changeTypeDetail" :value="typeDetail" />
                        <BaseRadio label="Cá nhân" id="personal" name="typeRadioDetail"  valueReal="2"  @change="changeTypeDetail" :value="typeDetail" />
                    </div>
                    <BaseCheckbox label="Là khách hàng" id="customer" styleCheckbox="margin-left:100px;"/>

                </div>
            </div>

            <div class="dialog-close">
               <BaseButtonIcon iconClass="btn-icon-help" @btnClick="action()" title="Giúp(F1)" />
               <BaseButtonIcon iconClass="btn-icon-close" @btnClick="action()" title="Đóng(ESC)" />
            </div>
        </div>

        <div class="dialog-body">
            
            <div class="dialog-line "></div>
            <div class="dialog-footer ">
                <div class="footer-left ">
                    <BaseButton label="Hủy"  @btnClick="btnCloseForm()" />
                </div>
                <div class="footer-right ">
                    <BaseButton label="Cất" title="Cất(Ctrl+S)" @btnClick="btnSave(1)" shortKey="['ctrl','s']"/>
                    &nbsp;&nbsp;
                    <BaseButton label="Cất và Thêm" :hasBackground="true" title="Cất và Thêm(Ctrl+Shift+S)" @btnClick="btnSave(2)" shortKey="['ctrl','shift','s']"/>
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
export default {
    components:{
        BaseButton,
        BaseButtonIcon,
        BaseRadio,
        BaseCheckbox
    },
    data() {
        return {
            typeDetail:'1'
        }
    },
    methods:{
        btnSave(value){
            alert("value "+ value);
        },
        btnCloseForm(){
            alert("Đóng form");
        },
        changeTypeDetail(){
            // alert("change type detail");
        }
        
    }
}
</script>
<style scoped>
@import url(../../style/view/account_object/account-detail.css);
</style>
