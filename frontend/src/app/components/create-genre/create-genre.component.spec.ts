import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGenreComponent } from './create-genre.component';

describe('CreateGenreComponent', () => {
  let component: CreateGenreComponent;
  let fixture: ComponentFixture<CreateGenreComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateGenreComponent]
    });
    fixture = TestBed.createComponent(CreateGenreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
