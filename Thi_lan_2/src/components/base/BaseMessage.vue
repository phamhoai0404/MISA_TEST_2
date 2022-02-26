<template>
<div class="m-message ">
    <div class="m-message-content">
        <div class="m-messages-body">
            <div class="m-mess-icon m-exclamation-question" :class="[]"></div>
            <div class="m-mess-title">{{titleForm}}
            </div>
        </div>
        <div class="m-message-line"></div>
        <div class="m-messages-footer-question">
            <div class="m-footer-left">
                 <BaseButton 
                    label="Hủy"
                    @btnClick="btnCancel"
                />
            </div>
            <div class="m-footer-right">
                <BaseButton 
                    label="Không"
                    @btnClick="btnYes"
                />
                &nbsp;&nbsp;
                <BaseButton 
                    label="Có"
                    :hasBackground="true"
                    @btnClick="btnYes"
                />
            </div>
        </div>
    </div>
</div>
</template>
<script>
import BaseButton from '@/components/base/BaseButton.vue'
export default {
    components:{
        BaseButton
    },
    props:{
        titleForm:String, // Thông điệp của messeage truyền từ cha vào con
        typeMessage:String //Xem Message thuộc loại nào để hiển thị cho phù hợp
    },
    methods:{
        btnYes(){},//Đồng ý
        btnNo(){},//Không đống ý
        btnCancel(){}//Hủy hành động đang muốn làm
    }
}
</script>
<style scoped>
 @import url(../../style/base/message.css);
</style>