<template>
    <div class="ca-ground">
        <div class="ca-menu">
            <router-link to="/CA/CAProcess"  class="ca-menu-item" id="CAProcess">Quy trình</router-link>
            <router-link to="/CA/CAReceipt" href="" class="ca-menu-item"  @click.native="removeActiveFirst()">Thu, chi tiền </router-link>
        </div>
        <div class="ca-content">
            <router-view></router-view>
        </div> 
    </div>
  
</template>

<script>
export default {
    mounted() {
        
        this.currentPath = this.$router.currentRoute.path;
        console.log( this.currentPath);
    },
    data() {
        return {
            currentPath: '',
        }
    },
    watch: {
        //để xem sự thay đổi thì lần đầu tiên đầu tiên
        currentPath: function (value) {
            value = this.$router.currentRoute.path;
            if (value == '/CA') {
                document.getElementById('CAProcess').classList.add('router-link-exact-active');
                document.getElementById('CAProcess').classList.add('router-link-active');
            } 
        }
    },
    methods: {
        removeActiveFirst() {
            this.currentPath = this.$router.currentRoute.path;
            if(this.currentPath != '/CA'){
                document.getElementById('CAProcess').classList.remove('router-link-exact-active');
                document.getElementById('CAProcess').classList.remove('router-link-active');
            }else{
                document.getElementById('CAProcess').classList.add('router-link-exact-active');
                document.getElementById('CAProcess').classList.add('router-link-active');
            }
        }
    }

}
</script>

<style scoped>
@import url(../../style/view/cash/ca.css);
</style>
