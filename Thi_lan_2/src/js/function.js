var MyFunction = {
    /**
     * Thực hiện tìm kiếm những giá trị trong dãy thỏa mãn dữ kiện đầu vào là và dãy ban đầu là arrayList value
     * .toLowerCase(): Thực hiện chuyển về chữ thường để so sánh cho được nhiều nhất
     * CreatedBy: HoaiPT(28/02/2022)
     */
    selectFilter(arrayList, value) {
        value = value.toLowerCase();
        return arrayList.filter(itemValue => itemValue.toLowerCase().includes(value));
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
     * Thực hiện so sánh hai giá trị
     * CreatedBy: HoaiPT(28/02/2022)
     */
    comparisonValue(value1, value2) {
        if (value1 != "" && value2 != "" && value1 != null & value2 != null) {

            // Chuyển hai đối tượng về dạng chữ thường hết
            if (value1.toLowerCase() == value2.toLowerCase()) {
                return true;
            }
        }
        return false;
    },
}
export default MyFunction