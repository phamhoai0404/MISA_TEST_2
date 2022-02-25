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
        onInput(event) {
        this.$emit('input', event.target.value)
      }
    },
}
</script>
<style scoped>
@import url('../../style/base/input-icon.css');

</style>
