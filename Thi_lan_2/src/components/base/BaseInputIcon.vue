<template>
<input type="text" class="m-input m-input-icon" :placeholder="[[placeholder]]" :value="value" @input="onInput">
</template>

<script>
export default {
    props: {
        placeholder: String,
        value:String
    },
    methods: {
        /**
         * Thực hiện khi thay đổi giá trị trong ô Input
         * CreatedBy: HoaiPT(25/02/2022)
         */
        onInput(event) {
        this.$emit('input', event.target.value)
      }
    },
}
</script>
<style scoped>
@import url('../../style/base/input-icon.css');

</style>
