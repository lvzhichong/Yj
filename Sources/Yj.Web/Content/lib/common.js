// ���ֵ�Ƿ�Ϊ��
function isNullOrEmpty(value) {
    if (value == undefined || value == null || value == '' || value.trim() == '') {
        return true;
    }
    return false;
}

// ��ȡurl����
function getUrlParam(name) {
    //Tolower
    name = name.toLowerCase();

    //����һ������Ŀ�������������ʽ����  
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    //ƥ��Ŀ�����  
    var r = window.location.search.toLowerCase().substr(1).match(reg);
    //���ز���ֵ  
    if (r != null) return unescape(r[2]);
    return "";
}