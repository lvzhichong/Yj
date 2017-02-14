// 检查值是否为空
function isNullOrEmpty(value) {
    if (value == undefined || value == null || value == '' || value.trim() == '') {
        return true;
    }
    return false;
}

// 获取url参数
function getUrlParam(name) {
    //Tolower
    name = name.toLowerCase();

    //构造一个含有目标参数的正则表达式对象  
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    //匹配目标参数  
    var r = window.location.search.toLowerCase().substr(1).match(reg);
    //返回参数值  
    if (r != null) return unescape(r[2]);
    return "";
}