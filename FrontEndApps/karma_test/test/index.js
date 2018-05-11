// describe(string, function) 分组，一组测试用例
// it(string, function)	测试用例
// expect(expression) 期望
// to***(arg) 匹配
// 	toBe()
// 	toNotBe()
// 	toBeDefined()
// 	toBeUndefined()
// 	toBeNull()
// 	toBeTruthy()
// 	toBeFalsy()
// 	toBeLessThan()
// 	toBeGreaterThan()
// 	toEqual()
// 	toNotEqual()
// 	toContain()
// 	toBeCloseTo()
// 	toHaveBeenCalled()
// 	toHaveBeenCalledWith()
// 	toMatch()
// 	toNotMatch()
// 	toThrow()
describe("A case for always true", function() {
    it("contains spec with an expectation", function() {
        console.log("This is the msg from log...");
        expect(true).toBe(true);
    })
})
describe('A case for isNum', function() {
    it('isNum() should work fine.', function() {
        expect(isNum(1)).toBe(true);
        expect(isNum('1')).toBe(false);
    })
})
describe('A case for reverse', function() {
    it('reverse() should work fine.', function() {
        expect(reverse('abcd')).toEqual('dcba');
        expect(reverse('1234')).toEqual('4321');
    })
})