import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ListReceitasComponent } from './list-receitas.component';

describe('ListReceitasComponent', () => {
  let component: ListReceitasComponent;
  let fixture: ComponentFixture<ListReceitasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListReceitasComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ListReceitasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
