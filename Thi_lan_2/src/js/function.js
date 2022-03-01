var MyFunction = {
    /**
     * Thực hiện định dạng lại ngày
     * CreatedBy: HoaiPT(08/02/2022)
     */
    formatDate: function(value) {
        if (value) {
            value = new Date(value);

            let date = value.getDate();
            date = date < 10 ? `0${date}` : date;

            let month = value.getMonth() + 1;
            month = month < 10 ? `0${month}` : month;

            let year = value.getFullYear();

            value = `${date}/${month}/${year}`;
        } else value = "";

        return value;
    },
    /**
     * Thực hiện tìm kiếm những giá trị trong dãy thỏa mãn dữ kiện đầu vào là và dãy ban đầu là arrayList value
     * .toLowerCase(): Thực hiện chuyển về chữ thường để so sánh cho được nhiều nhất
     * CreatedBy: HoaiPT(28/02/2022)
     */
    selectFilter(arrayList, value) {
        if (value != null) {
            value = value.toLowerCase();
        }
        return arrayList.filter(itemValue => itemValue.toLowerCase().includes(value));
    },
    /**
     * Thực hiện tìm kiếm những giá trị trong dãy thỏa mãn dữ kiện đầu vào là và dãy ban đầu là arrayList ĐỐI TƯỢNG value
     * .toLowerCase(): Thực hiện chuyển về chữ thường để so sánh cho được nhiều nhất
     * CreatedBy: HoaiPT(01/03/2022)
     */
    selectFilterObject(arrayList, nameProperty, value) {
        if (value != null) {
            value = value.toLowerCase();
        }
        return arrayList.filter(itemValue => itemValue[nameProperty].toLowerCase().includes(value));
    },
    /**
     * Thực hiện kiểm tra xem giá trị có tồn tại trong dãy
     * CreatedBy: HoaiPT(28/02/2022)
     */
    existValueInArray(arrayList, value) {
        if (value != null) { //Nếu giá trị tồn tại
            value = value.toLowerCase(); //Thực hiện chuyển value về toàn bộ là chữ thường
            let arrayListTemp = arrayList.filter(itemValue => itemValue.toLowerCase() == value);
            if (arrayListTemp.length > 0)
                return true;
        }
        return false;
    },
    /**
     * Thực hiện kiểm tra xem giá trị có tồn tại trong dãy gồm các đối tượng
     * CreatedBy: HoaiPT(01/03/2022)
     */
    existValueInArrayObject(arrayList, nameProperty, value) {
        if (value != null) { //Nếu giá trị tồn tại
            value = value.toLowerCase(); //Thực hiện chuyển value về toàn bộ là chữ thường
            let arrayListTemp = arrayList.filter(itemValue => itemValue[nameProperty].toLowerCase() == value);
            if (arrayListTemp.length > 0)
                return true;
        }
        return false;
    },
    /**
     * Thực hiện so sánh hai giá trị
     * CreatedBy: HoaiPT(28/02/2022)
     */
    comparisonValue(value1, value2) {
        // console.log("giá trị: ", value1, )
        if (value1 != "" && value2 != "" && value1 != null & value2 != null) {

            // Chuyển hai đối tượng về dạng chữ thường hết
            if (value1.toLowerCase() == value2.toLowerCase()) {
                return true;
            }
        }
        return false;
    },
    sameObject(objectTarget) {
        let objectTemp = {}; //Tạm thời
        for (var propName in objectTarget) {
            objectTemp[propName] = objectTarget[propName];
        }
        return objectTemp; //Trả về đối tượng muốn lấy mà không dính tới bind
    },
}
export default MyFunction