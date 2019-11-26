import { TityoAttendanceTemplatePage } from './app.po';

describe('TityoAttendance App', function() {
  let page: TityoAttendanceTemplatePage;

  beforeEach(() => {
    page = new TityoAttendanceTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
