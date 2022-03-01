<template>
<div class="m-message ">
    <div class="m-message-content">
        <div class="m-messages-body">

            <!-- Xem Message thuộc loại nào để hiển thị icon cho phù hợp -->
            <div class="m-mess-icon" :class="[
                typeMessage=='warning'?'m-icon-warning':'' ||
                typeMessage=='warningAndQuestion'?'m-icon-warning':'' ||
                typeMessage=='info'?'m-icon-info':'' ||
                typeMessage=='question'?'m-exclamation-question':'' 
            ]"></div>

            <!--Thông tin hiển thị ở đây  -->
            <div class="m-mess-title">{{titleForm}}
            </div>
        </div>
        <div class="m-message-line"></div>

        <!-- Footer thể hiện đúng loại message định nghĩa -->

        <!--  QUESTION -->
        <div v-if="typeMessage=='question'" class="m-messages-footer-question">
            <div class="m-footer-left">
                <BaseButton label="Hủy" @btnClick="btnCancel" />
            </div>
            <div class="m-footer-right">
                <BaseButton label="Không" @btnClick="btnNo" />
                &nbsp;&nbsp;
                <BaseButton label="Có" :hasBackground="true" @btnClick="btnYes" />
            </div>
        </div>

        <!-- INFO -->
        <div v-if="typeMessage=='info'" class="m-messages-footer-info">
            <BaseButton label="Đóng" :hasBackground="true" @btnClick="btnClose" />
        </div>

        <!-- WARNING AND QUESTION -->
        <div v-if="typeMessage=='warningAndQuestion'" class="m-messages-footer-question">
            <div class="m-footer-left">
                <BaseButton label="Không" @btnClick="btnNo" />
            </div>
            <div class="m-footer-right">
                <BaseButton label="Có" :hasBackground="true" @btnClick="btnYes" />
            </div>
        </div>

        <!-- WARNING -->
        <div v-if="typeMessage=='warning'" class="m-messages-footer-question">
            <div class="m-footer-left">
            </div>
            <div class="m-footer-right">
                <BaseButton label="Đồng ý" :hasBackground="true" @btnClick="btnYes" />
            </div>
        </div>

    </div>
</div>
</template>

<script>
import BaseButton from '@/components/base/BaseButton.vue'
export default {
    components: {
        BaseButton
    },
    props: {
        titleForm: { // Thông điệp của messeage truyền từ cha vào con
            type: String,
            // required: true
        },
        typeMessage: {
            type: String, //Xem Message thuộc loại nào để hiển thị cho phù hợp
            required: true,
        }
    },
    methods: {
        btnYes() {
            var me = this;
            me.$emit('btnYes');
        }, //Đồng ý
        btnNo() {
            var me = this;
            me.$emit('btnNo');
        }, //Không đống ý
        btnCancel() {
            var me = this;
            me.$emit('btnCancel');
        }, //Hủy hành động đang muốn làm
        btnClose() {
            var me = this;
            me.$emit('btnClose');
        } //Thực hiện đóng
    }
}
</script>

<style scoped>
@import url(../../style/base/message.css);
</style>
