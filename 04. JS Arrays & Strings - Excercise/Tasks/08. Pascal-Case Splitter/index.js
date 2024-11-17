function solve(sentence){
    console.log(sentence.match(/[A-Z][a-z]*/g).join(', '));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');