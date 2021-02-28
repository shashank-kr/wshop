import mapNavService from "@/mapNavService.js";

describe("mapNavService.js: isOutOfBounds", () => {
  const mapNav = mapNavService(5, 5);
  it("returns false at (0,0)", () => {
    const coords = { x: 0, y: 0 };
    let result = mapNav.isOutOfBounds(coords);
    expect(result).toBe(false);
  });
  it("returns true if out of bounds to the S", () => {
    const coords = { x: 0, y: -1 };
    let result = mapNav.isOutOfBounds(coords);
    expect(result).toBe(true);
  });
  it("returns true if out of bounds to the N", () => {
    const coords = { x: 0, y: 5 };
    let result = mapNav.isOutOfBounds(coords);
    expect(result).toBe(true);
  });
  it("returns true if out of bounds to the E", () => {
    const coords = { x: 5, y: 0 };
    let result = mapNav.isOutOfBounds(coords);
    expect(result).toBe(true);
  });
  it("returns true if out of bounds to the W", () => {
    const coords = { x: -1, y: 0 };
    let result = mapNav.isOutOfBounds(coords);
    expect(result).toBe(true);
  });
});

describe("mapNavService.js: hasCollided", () => {
  const mapNav = mapNavService(5, 5);
  it("returns true if coordinates match an object in obstacles array", () => {
    const coords = { x: 0, y: 0 };
    const obstacles = [{ x: 0, y: 0 }];
    let result = mapNav.hasCollided(coords, obstacles);
    expect(result).toBe(true);
  });
  it("returns false if coordinates do not match an object in obstacles array", () => {
    const coords = { x: 0, y: 0 };
    const obstacles = [{ x: 0, y: 1 }];
    let result = mapNav.hasCollided(coords, obstacles);
    expect(result).toBe(false);
  });
});

describe("mapNavService.js: getPositionFromSequence", () => {
  const mapNav = mapNavService(5, 5);
  it("returns startPosition if sequence is empty", () => {
    const sequence = "";
    const start = { x: 0, y: 0, orientation: "N" };
    let result = mapNav.getPositionFromSequence(sequence, start);
    expect(result).toMatchObject(start);
  });
  it("does not return startPosition if rover has moved", () => {
    const sequence = "M";
    const start = { x: 0, y: 0, orientation: "N" };
    let result = mapNav.getPositionFromSequence(sequence, start);
    expect(result).not.toMatchObject(start);
  });
  it("returns correct position with sequence of RMLM", () => {
    const sequence = "RMLM";
    const start = { x: 0, y: 0, orientation: "N" };
    const expected = { x: 1, y: 1, orientation: "N" };
    let result = mapNav.getPositionFromSequence(sequence, start);
    expect(result).toMatchObject(expected);
  });
});
