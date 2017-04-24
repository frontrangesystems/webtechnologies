import { FrsWebTechnologiesPage } from './app.po';

describe('frs-web-technologies App', () => {
  let page: FrsWebTechnologiesPage;

  beforeEach(() => {
    page = new FrsWebTechnologiesPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
