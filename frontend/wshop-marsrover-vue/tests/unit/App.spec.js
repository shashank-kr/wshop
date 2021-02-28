import { mount } from "@vue/test-utils";
import App from "@/App.vue";

describe("App.vue", () => {
  it("renders with a grid", () => {
    const wrapper = mount(App);
    expect(wrapper.contains("div.grid")).toBe(true);
  });
});
