var MyFunction2 = {
    /**
     * Kiểm tra xem có tồn tại đối tượng hay không, đối tượng đó cũng phải khác có tất cả object[prop] =="", chỉ cần object[prop].trim() !="" thì có tồn tại
     * CreateBy: HoaiPT(04/03/2022)
     */
    existObject(object) {
        console.log("vào đây")
        if (Object.keys(object).length != 0) {
            for (let propName in object) {
                if (object[propName].trim() != "") {
                    return true;
                }
            }
        }
        return false; //Nó không có đối tượng nào cả
    },

}
export default MyFunction2