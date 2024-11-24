function NxN(num){
    const result = ((num + ' ').repeat(num) + '\n').repeat(num);
    console.log(result);
}
NxN(3);
NxN(7);
NxN(2);