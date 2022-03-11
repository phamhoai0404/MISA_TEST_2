<template>
<div>
    <div @click="test">Test</div>
</div>
</template>

<script>
import axios from 'axios'
export default {
    methods: {
        test() {
            let strings = "hoaaa";
            let numbers = 10;
            let objectssss = {};
            axios.post(`https://localhost:44338/api/v1/CaPaymentDetails/CodeNe?hoa=${strings}&uu=${numbers}`, objectssss)
                .then(function () {
                    console.log("được");
                })
                .catch(function () {
                    console.log("không được");
                })

        }
    },
}
</script>
