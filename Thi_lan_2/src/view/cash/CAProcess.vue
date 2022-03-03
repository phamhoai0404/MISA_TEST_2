<template>
<div class="process">

    <div class="process-left">
        <div class="title">
            NGHIỆP VỤ TIỀN MẶT
        </div>
        <div class="process-background">
            <a class="collect-money">
                <div>Thu tiền </div>
            </a>
            <a class="inventory">
                <div>Kiểm kê quỹ</div>
            </a>
            <a class="pay-money">
                <div>Chi tiền</div>
            </a>
        </div>
        <div class="process-footer">
            <a class="process-item">
                <div class="icon-process customer"></div>
                <div class="icon-title">Khách hàng</div>
            </a>
            <router-link to="/account" class="process-item">
                <div class="icon-process provider"></div>
                <div class="icon-title">Nhà cung cấp</div>
            </router-link>
            <a class="process-item">
                <div class="icon-process employee"></div>
                <div class="icon-title">Nhân viên</div>
            </a>
            <a class="process-item">
                <div class="icon-process calculate"></div>
                <div class="icon-title">Tính tỉ giá xuất quỹ</div>
            </a>
        </div>

    </div>
    <div class="process-right">
        <div class="title">
            BÁO CÁO
        </div>
        <div class="group-report">
            <ul>
                <li>Bảng kê số dư theo ngày</li>
                <li>Dòng tiền</li>
                <li>S03a1-DN: Sổ nhật ký thu tiền</li>
                <li>Sổ kế toán chi tiết quỹ tiền mặt</li>
                <li style="border:none">S03a2-DN: Sổ nhật ký chi tiền</li>
            </ul>
            <div class="right-footer">
                Tất cả báo cáo
            </div>
        </div>

    </div>

</div>
</template>

<style scoped>
@import url(../../style/view/cash/ca-process.css);
</style>
