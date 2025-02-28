function rotate(array, count){
    let arrayTemp = array;
    for(let i = 0; i < count; i++){
        const firstElement = arrayTemp.shift();
        arrayTemp.push(firstElement);
    }
    console.log(arrayTemp.join(' '));
}
rotate([51, 47, 32, 61, 21], 2);
rotate([32, 21, 61, 1], 4);
rotate([2, 4, 15, 31], 5);