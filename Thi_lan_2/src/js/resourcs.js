var resourcs = {
    VI: {
        errorMsg: "Có lỗi xảy ra vui lòng liên hệ Misa! ",
        titlePage: " bản ghi trên 1 trang",
        fileNameExport: "Danh_sach_nhan_vien",
        deleteMulti: "Bạn thực sự có muốn xóa những nhân viên đã chọn không?",
        confirmEdit: "Dữ liệu đã bị thay đổi bạn có muốn cất không?",
        errorEmployeeCode: "Mã nhân viên không đúng định dạng!",
        notNullFullName: "Tên không được phép để trống!",
        notNullEmployeeCode: "Mã không được phép để trống!",
        notNullDepartmentName: "Đơn vị không được phép để trống!",
        inputSearch: "Nhập từ khóa tìm kiếm",
    }
}
var misaEnum = {
    gender: {
        Male: "1",
        Female: "0",
        Other: "2"
    },
    genderNumber: {
        Male: {
            Value: 1,
            Text: "Nam"
        },
        Female: {
            Value: 0,
            Text: "Nữ"
        },
        Other: {
            Value: 2,
            Text: "Khác"
        }
    },
    editMode: {
        Add: 1, //Thực hiện thêm mới
        Edit: 2 //Thực hiện sửa
    },
    actionDelete: {
        NoAction: 0, //Không xóa
        One: 1, //Xóa một 
        Multi: 2, //Xóa nhiều
    }
}
var data = {
    listPageSize: [
        "10", "20", "30", "50", "100"
    ],
    listFieldAccountObject: [{
            name: "AccountObjectCode",
            text: "MÃ NHÀ CUNG CẤP",
            width: "200",
            type: "date"
        },
        {
            name: "AccountObjectName",
            text: "TÊN NHÀ CUNG CẤP",
            width: "200",
        },
        {
            name: "Address",
            text: "ĐỊA CHỈ",
            width: "500",
            type: "number"
        },
        {
            name: "TaxCode",
            text: "MÃ SỐ THUẾ",
            width: "200",
            type: "number"
        },
        {
            name: "Phone",
            text: "SỐ ĐIỆN THOẠI",
            width: "200",
        },
        {
            name: "Website",
            text: "WEBSITE",
            width: "200",
            title: "Tên trang web công ty"
        },

    ]
}

export {
    resourcs,
    misaEnum,
    data
};