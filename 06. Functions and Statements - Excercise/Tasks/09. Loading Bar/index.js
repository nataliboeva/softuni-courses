function loadingBar(percentage){
    const barsLength = 10;
    const barsFilled = Math.round(percentage / barsLength);
    const barsEmpty = barsLength - barsFilled;

    if(barsEmpty == 0){
        console.log('100% Complete!');
        console.log(`[${'%'.repeat(barsFilled)}]`)
    }
    else{
        console.log(`${percentage}% [${'%'.repeat(barsFilled)}${'.'.repeat(barsEmpty)}]`);
        console.log('Still loading...');
    }
}
loadingBar(30);
loadingBar(50);
loadingBar(100);