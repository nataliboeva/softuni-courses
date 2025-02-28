function reverse(n, input){
    let arrayN = [];
    for(let i = 0; i < n; i++){
        arrayN.push(input[i]);
    }
    let reverseN = arrayN.reverse();
    console.log(reverseN.join(' '));
}
reverse(3, [10, 20, 30, 40, 50]);
reverse(4, [-1, 20, 99, 5]);
reverse(2, [66, 43, 75, 89, 47]);