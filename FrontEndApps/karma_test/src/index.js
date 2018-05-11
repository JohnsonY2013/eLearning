function isNum(num) {
    if (typeof num === 'number') {
        return true
    } else {
        return false
    }
}

function reverse(str){
	// if(str == 'ABC') return 'CBA';
	return str.split("").reverse().join("");
}