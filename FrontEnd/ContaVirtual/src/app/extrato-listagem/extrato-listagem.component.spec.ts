import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtratoListagemComponent } from './extrato-listagem.component';

describe('ExtratoListagemComponent', () => {
  let component: ExtratoListagemComponent;
  let fixture: ComponentFixture<ExtratoListagemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExtratoListagemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExtratoListagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
