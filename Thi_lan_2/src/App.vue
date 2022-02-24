<template>
<div>
    <div class="page">
        <div class="page-left">
            <TheMenu />
        </div>
        <div class="page-right">
            <TheHeaderTop />
            <div class="page-content">
                <router-view></router-view>
            </div>
        </div>
        <!-- <Loading/> -->
    </div>
</div>
</template>

<script>
import TheMenu from '@/components/layout/TheMenu.vue'
import TheHeaderTop from '@/components/layout/TheHeaderTop.vue'
// import Loading from '@/components/base/BaseLoading.vue'


export default {
    name: 'App',
    components: {
        TheMenu,
        TheHeaderTop,
        // Loading
    },
    methods: {

    },

}
</script>

<style>
@import url(./style/main.css);

.page {
    display: flex;
    width: 100%;
    max-height: 100vh;
    min-height: 100vh;
    box-sizing: border-box;
}

.page .page-left {
    min-width: 187px;
    max-width: 187px;
}

.page .page-right {
    max-width: calc(100% - 187px);
    min-width: calc(100% - 187px);
    box-sizing: border-box;

}

.page-content {
    padding-top: 0px;
    padding-right: 0px;
    padding-left: 20px;
    background-color: #f4f5f8;
    min-height: calc(100% - 48px);
    max-height: calc(100% - 48px);
    max-width: 100%;

    overflow: hidden;
    box-sizing: border-box;

}

</style>
