function checkIfPalindrome(numbers){
    const isPalindrome = (num) =>{
        const strNum = num.toString();
        const strNumReversed = strNum.split('').reverse().join('');
        
        return strNum === strNumReversed;
    }
    numbers.forEach(element => {
        console.log(isPalindrome(element));
    });
}
checkIfPalindrome([123,323,421,121]);