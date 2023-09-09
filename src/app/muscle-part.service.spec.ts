import { TestBed } from '@angular/core/testing';

import { MusclePartService } from './muscle-part.service';

describe('MusclePartService', () => {
  let service: MusclePartService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MusclePartService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
