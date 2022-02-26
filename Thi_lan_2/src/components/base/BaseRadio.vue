<template>
<div>
    <div class="m-item-group">
        <input type="radio" class="m-item-radio" :id="id" :name="name" :value="valueReal" v-model="radioButtonValue">
        <label class="m-item-content" :for="id">
            <span></span>
            {{label}}
        </label>
    </div>
</div>
</template>

<script>
export default {
    computed: {
        /**
         * Thực hiện định nghĩa lại cho model truyền vào
         * CreatedBy: HoaiPT(26/02/2022)
         */
        radioButtonValue: {
            get: function () {
                return this.value; //Thiết lập như vậy thì v-model này chính bằng cái v-model ngoài thằng cha
            },
            set: function () {
                this.$emit("change", this.valueReal); // Thiết lập giá trị mới bắn cho thằng cha
            }
        }
    },
    /**
     * Truyền từ cha vào con
     * CreatedBy: HoaiPT(26/02/2022)
     */
    props: {
        id: { //Xác định id
            default: '',
            type: String,
        },
        name: { //Xác định name muốn nó chọn cái này hay cái kia thì cần phải có name giống nhau
            default: '',
            type: String,
        },
        label: { //Xác định nhãn cho từng cái
            default: '',
            type: String
        },
        value: String, //đây là v-model của nó 
        valueReal: String, //Đây là giá trị thực của nó 
    }
}
</script>

<style scoped>
@import url(../../style/base/radio.css);
</style>
